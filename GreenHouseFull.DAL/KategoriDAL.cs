using GreenHouseFull.Core.Context;
using GreenHouseFull.DTO;
using GreenHouseFull.ExceptionHandling;
using GreenHouseFull.Log;
using GreenHouseFull.Mapping;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DAL
{
    public class KategoriDAL
    {
        private ILogger<LogDTO> _logger;

        /// <summary>
        /// Uses NLogLogger to log to the specified file.
        /// </summary>
        /// <param name="logFileName">Name of the log file. Only Name.</param>
        public KategoriDAL(string logFileName = "Kategori_Log")
        {
            _logger = new NLogLogger<LogDTO>(logFileName);
        }

        public KategoriDAL(ILogger<LogDTO> logger)
        {
            _logger = logger;
        }

        #region Admin

        /// <summary>
        /// Adds new category. For admin usage.
        /// </summary>
        /// <param name="kategoriAdi">Category name to be added</param>
        /// <param name="ustKat">Id of category above if there is any</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns>KategoriWithUstDTO</returns>
        /// <exception cref="ExistsException">Thrown when same category exists</exception>
        public KategoriWithUstDTO KategoriEkleAdmin(string kategoriAdi, KategoriSimpleListDTO ustKat, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Add;
            logDTO.MethodName = "KategoriEkleAdmin";

            try
            {
                ProDAL<Kategori> kategoriDAL = new ProDAL<Kategori>();
                Kategori kategori = kategoriDAL.GetByFirst(x => x.Adi.ToLower() == kategoriAdi.ToLower());

                if (kategori != null)
                {
                    //Same categry exists
                    if (kategori.isActive)
                        throw new ExistsException("Bu isimde bir kategori mevcut.");
                    else
                    {
                        //Exists but inactive so make it active
                        kategori.isActive = true;
                        kategori.UstKategoriId = ustKat?.Id;
                        kategori.ModifiedBy = currentUserId;
                        kategori.ModifiedDate = DateTime.Now;
                    }
                }
                else
                {
                    //Add new category
                    kategori = new Kategori()
                    {
                        Adi = kategoriAdi,
                        UstKategoriId = ustKat?.Id,
                        CreatedBy = currentUserId,
                        ModifiedBy = currentUserId,
                        isActive = true,
                        ModifiedDate = DateTime.Now,
                        CreatedDate = DateTime.Now
                    };
                    kategoriDAL.Add(kategori);
                }

                kategoriDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı kategori {kategoriAdi} ekleme işlemi.";

                _logger.DoLog(logDTO);

                return new KategoriWithUstDTO()
                {
                    KategoriId = kategori.Id,
                    Name = kategoriAdi,
                    UstName = ustKat?.Adi
                };
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız kategori {kategoriAdi} ekleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw agan
                throw;
            }
        }

        /// <summary>
        /// Updates category info. For admin usage.
        /// </summary>
        /// <param name="kategoriSimpleListDTO">Old category id, new name</param>
        /// <param name="ustKatId">New top cateogry info</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns>true if successful</returns>
        /// <exception cref="ExistsException">Thrown when a different has the name</exception>
        public bool KategoriGuncelleAdmin(KategoriSimpleListDTO kategoriSimpleListDTO, int? ustKatId, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Update;
            logDTO.MethodName = "KategoriGuncelleAdmin";

            try
            {
                ProDAL<Kategori> kategoriDAL = new ProDAL<Kategori>();

                Kategori existsCheck = kategoriDAL.GetByFirst(x => x.Adi.ToLower() == kategoriSimpleListDTO.Adi.ToLower() && x.Id != kategoriSimpleListDTO.Id);

                if (existsCheck != null)
                {
                    //Different category has the name
                    if (existsCheck.isActive)
                        throw new ExistsException("Güncellemeye çalıştığınız isimde bir kategori mevcut.");
                    else
                        throw new ExistsException("Güncellemeye çalıştığınız isim sistemde mevcut ancak aktif değil.");
                }

                Kategori kategori = kategoriDAL.GetByID(kategoriSimpleListDTO.Id);

                //Update
                kategori.Adi = kategoriSimpleListDTO.Adi;
                kategori.UstKategoriId = ustKatId;
                kategori.ModifiedBy = currentUserId;
                kategori.ModifiedDate = DateTime.Now;

                kategoriDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı kategori {kategori.Adi} güncelleme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız kategori {kategoriSimpleListDTO.Id} ID güncelleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw agan
                throw;
            }
        }

        /// <summary>
        /// Soft erases the category. For admin usage.
        /// </summary>
        /// <param name="kategoriId">Category Id to be erased</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns>true if successful</returns>
        public bool KategoriSilAdmin(int kategoriId, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Erase;
            logDTO.MethodName = "KategoriSilAdmin";

            try
            {
                ProDAL<Kategori> kategoriDAL = new ProDAL<Kategori>();

                Kategori kategori = kategoriDAL.GetByID(kategoriId);

                //Erase
                kategori.isActive = false;
                kategori.ModifiedBy = currentUserId;
                kategori.ModifiedDate = DateTime.Now;

                kategoriDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı kategori {kategori.Adi} silme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız kategori {kategoriId} ID silme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw agan
                throw;
            }
        }

        /// <summary>
        /// Gets all categories with their top category info
        /// </summary>
        /// <returns>List of KategoriWithUstDTO</returns>
        public List<KategoriWithUstDTO> GetAllKategoriWithUsts(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetAllKategoriWithUsts";

            try
            {
                ProDAL<Kategori> kDal = new ProDAL<Kategori>();

                //Pull categories
                List<Kategori> kategoris = kDal.GetBy(k => k.isActive);

                //Map
                List<KategoriWithUstDTO> kategoriWithUstsList = new List<KategoriWithUstDTO>();
                GreenHouseMapper mapper = new GreenHouseMapper();
                foreach (var kategori in kategoris)
                {
                    kategoriWithUstsList.Add(mapper.MapKategoriKategoriWithUstsDTO(kategori));
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı kategorileri çekme işlemi.";

                _logger.DoLog(logDTO);

                return kategoriWithUstsList;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız kategorileri çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw agan
                throw;
            }
        }

        #endregion

        /// <summary>
        /// Gets all categories with basic info
        /// </summary>
        /// <returns>List of KategoriSimpleListDTO</returns>
        public List<KategoriSimpleListDTO> GetAllKategoriForListing(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetAllKategoriForListing";

            try
            {
                ProDAL<Kategori> kDal = new ProDAL<Kategori>();

                List<Kategori> kategoris = kDal.GetBy(k => k.isActive);

                List<KategoriSimpleListDTO> kategoriSimpleListDTOs = new List<KategoriSimpleListDTO>();

                GreenHouseMapper mapper = new GreenHouseMapper();
                foreach (var kategori in kategoris)
                {
                    kategoriSimpleListDTOs.Add(mapper.MapKategoriKategoriSimpleListDTO(kategori));
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı kategorileri çekme işlemi.";

                _logger.DoLog(logDTO);

                return kategoriSimpleListDTOs;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız kategorileri çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw agan
                throw;
            }
        }
    }
}
