using GreenHouseFull.Common;
using GreenHouseFull.Core.Context;
using GreenHouseFull.DTO;
using GreenHouseFull.ExceptionHandling;
using GreenHouseFull.Log;
using GreenHouseFull.Mapping;
using GreenHouseFull.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DAL
{
    public class UrunDuzeltmeTalepDAL
    {
        private ILogger<LogDTO> _logger;

        /// <summary>
        /// Uses NLogLogger to log to the specified file.
        /// </summary>
        /// <param name="logFileName">Name of the log file. Only Name.</param>
        public UrunDuzeltmeTalepDAL(string logFileName = "UrunDuzeltmeTalep_Log")
        {
            _logger = new NLogLogger<LogDTO>(logFileName);
        }

        public UrunDuzeltmeTalepDAL(ILogger<LogDTO> logger)
        {
            _logger = logger;
        }

        #region Admin

        /// <summary>
        /// Gets the product adjustment request basic info
        /// </summary>
        /// <returns>List of DuzeltmeTalepListeDTO</returns>
        public List<DuzeltmeTalepListeDTO> GetTaleps(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetTaleps";

            try
            {
                List<DuzeltmeTalepListeDTO> duzeltmeTalepListeDTOs;

                using (MyDbContext db = new MyDbContext())
                {
                    duzeltmeTalepListeDTOs = (from udt in db.UrunDuzeltmeTalep
                                              where udt.isActive
                                              join u in db.Urun on udt.UrunId equals u.Id
                                              where u.isActive
                                              select new DuzeltmeTalepListeDTO()
                                              {
                                                  Id = udt.Id,
                                                  UrunAdi = u.Adi,
                                                  OnayDurumId = (Commons.OnayDurum)udt.OnayDurumId
                                              }).OrderBy(x => x.OnayDurumId).ToList();
                }

                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün düzeltme talepleri çekme işlemi.";

                _logger.DoLog(logDTO);

                return duzeltmeTalepListeDTOs;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün düzeltme talepleri çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Gets the product adjustment request details
        /// </summary>
        /// <param name="talepId">Request Id to get the details</param>
        /// <returns>DuzeltmeTalepListeEkAciklamaResimDTO</returns>
        public DuzeltmeTalepListeEkAciklamaResimDTO GetTalepDetail(int talepId, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetTalepDetail";

            try
            {
                DuzeltmeTalepListeEkAciklamaResimDTO ekDetail;

                ProDAL<UrunDuzeltmeTalep> talepDAL = new ProDAL<UrunDuzeltmeTalep>();

                UrunDuzeltmeTalep talep = talepDAL.GetByID(talepId);

                ekDetail = new DuzeltmeTalepListeEkAciklamaResimDTO()
                {
                    Aciklama = talep.Aciklama,
                    OnayAciklama = talep.OnayAciklama,
                    Resim = talep.Resim
                };

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün düzeltme talep {talepId} ID detay çekme işlemi.";

                _logger.DoLog(logDTO);

                return ekDetail;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün düzeltme talep {talepId} ID detay çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Updates the product adjustment request
        /// </summary>
        /// <param name="guncelleODT">Request to be updated</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns>true if successful</returns>
        public bool TalepGuncelleAdmin(DuzeltmeTalepGuncelleODT guncelleODT, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Update;
            logDTO.MethodName = "TalepGuncelleAdmin";

            try
            {
                ProDAL<UrunDuzeltmeTalep> talepDAL = new ProDAL<UrunDuzeltmeTalep>();

                UrunDuzeltmeTalep talep = talepDAL.GetByID(guncelleODT.Id);

                talep.OnayDurumId = (int)guncelleODT.OnayDurumId;
                talep.OnayAciklama = guncelleODT.OnayAciklama;
                talep.ModifiedBy = currentUserId;
                talep.ModifiedDate = DateTime.Now;

                talepDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün düzeltme talep {guncelleODT.Id} ID güncelleme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün düzeltme talep {guncelleODT.Id} ID güncelleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Soft erases the product adjustment request
        /// </summary>
        /// <param name="talepId">Request to be erased</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns>true if successful</returns>
        public bool TalepSilAdmin(int talepId, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Erase;
            logDTO.MethodName = "TalepSilAdmin";

            try
            {
                ProDAL<UrunDuzeltmeTalep> talepDAL = new ProDAL<UrunDuzeltmeTalep>();

                UrunDuzeltmeTalep talep = talepDAL.GetByID(talepId);

                talep.isActive = false;
                talep.ModifiedBy = currentUserId;
                talep.ModifiedDate = DateTime.Now;

                talepDAL.SaveMyChanges();

                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün düzeltme talep {talepId} ID silme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün düzeltme talep {talepId} ID silme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        #endregion

        /// <summary>
        /// Adds new product adjustment request
        /// </summary>
        /// <param name="talepDTO">New product adjustment request</param>
        /// <returns>true if successful</returns>
        public bool UrunDuzeltmeTalepEkle(UrunDuzeltmeTalepEkleDTO talepDTO)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = talepDTO.CreatedBy;
            logDTO.OperationType = IslemTur.Add;
            logDTO.MethodName = "UrunDuzeltmeTalepEkle";

            UrunDuzeltmeTalepEkleValidation ekleValidation = new UrunDuzeltmeTalepEkleValidation(talepDTO);

            try
            {
                if (!ekleValidation.IsValid)
                    throw new ModelNotValidException(ekleValidation.ValidationMessages);

                GreenHouseMapper greenHouseMapper = new GreenHouseMapper();

                ProDAL<UrunDuzeltmeTalep> db = new ProDAL<UrunDuzeltmeTalep>();
                UrunDuzeltmeTalep talep = greenHouseMapper.MapUrunDuzeltmeTalepEkleDTO(talepDTO);

                db.Add(talep);

                db.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün düzeltme talep {talep.Id} ID ekleme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (ModelNotValidException ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün {talepDTO.UrunId} ID için ürün düzeltme talep ekleme işlemi. Hata mesajı: " + string.Join(" ; ", ex.ValidationMessages);

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün {talepDTO.UrunId} ID için ürün düzeltme talep ekleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }
    }
}
