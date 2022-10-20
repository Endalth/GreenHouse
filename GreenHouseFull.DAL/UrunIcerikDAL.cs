using GreenHouseFull.Common;
using GreenHouseFull.Core.Context;
using GreenHouseFull.DTO;
using GreenHouseFull.ExceptionHandling;
using GreenHouseFull.Log;
using GreenHouseFull.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Proxies;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DAL
{
    public class UrunIcerikDAL
    {
        private ILogger<LogDTO> _logger;

        /// <summary>
        /// Uses NLogLogger to log to the specified file.
        /// </summary>
        /// <param name="logFileName">Name of the log file. Only Name.</param>
        public UrunIcerikDAL(string logFileName = "UrunIcerik_Log")
        {
            _logger = new NLogLogger<LogDTO>(logFileName);
        }

        public UrunIcerikDAL(ILogger<LogDTO> logger)
        {
            _logger = logger;
        }

        #region Admin

        /// <summary>
        /// Gets all product contents for admin usage.
        /// </summary>
        /// <param name="currentUserId">Admin</param>
        /// <returns>List of UrunIcerikAdminDTO</returns>
        public List<UrunIcerikAdminDTO> GetAllIcerik(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetAllIcerik";

            try
            {
                ProDAL<UrunIcerik> urunIcerikDAL = new ProDAL<UrunIcerik>();

                List<UrunIcerik> urunIceriks = urunIcerikDAL.GetBy(x => x.isActive);

                List<UrunIcerikAdminDTO> urunIcerikAdminDTOs = urunIceriks.Select(x => new UrunIcerikAdminDTO()
                {
                    Id = x.Id,
                    Adi = x.Adi,
                    Aciklama = x.Aciklama,
                    RiskSeviyeId = (Commons.RiskSeviye)x.RiskSeviyeId
                }).ToList();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün içerikleri çekme işlemi.";

                _logger.DoLog(logDTO);

                return urunIcerikAdminDTOs;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün içerikleri çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw ex;
            }
        }

        /// <summary>
        /// Adds new product content
        /// </summary>
        /// <param name="urunIcerikAdminDTO">New product content information</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns>UrunIcerikAdminDTO</returns>
        /// <exception cref="ExistsException">Thrown if a product content with the same name exists</exception>
        public UrunIcerikAdminDTO UrunIcerikEkleAdmin(UrunIcerikAdminDTO urunIcerikAdminDTO, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Add;
            logDTO.MethodName = "UrunIcerikEkleAdmin";

            try
            {
                ProDAL<UrunIcerik> urunIcerikDAL = new ProDAL<UrunIcerik>();

                UrunIcerik urunIcerik = urunIcerikDAL.GetByFirst(x => x.Adi.ToLower() == urunIcerikAdminDTO.Adi.ToLower());

                if (urunIcerik != null)
                {
                    //Same product content name exists
                    if (urunIcerik.isActive)
                        throw new ExistsException("Bu isimde ürün içeriği mevcut.");
                    else
                    {
                        //Same product content exists but inactive so make it active
                        urunIcerik.RiskSeviyeId = (int)urunIcerikAdminDTO.RiskSeviyeId;
                        urunIcerik.Aciklama = urunIcerikAdminDTO.Aciklama;
                        urunIcerik.isActive = true;
                        urunIcerik.ModifiedBy = currentUserId;
                        urunIcerik.ModifiedDate = DateTime.Now;
                    }
                }
                else
                {
                    //Add new product content
                    urunIcerik = new UrunIcerik()
                    {
                        Adi = urunIcerikAdminDTO.Adi,
                        Aciklama = urunIcerikAdminDTO.Aciklama,
                        RiskSeviyeId = (int)urunIcerikAdminDTO.RiskSeviyeId,
                        CreatedBy = currentUserId,
                        ModifiedBy = currentUserId,
                        isActive = true,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    };

                    urunIcerikDAL.Add(urunIcerik);
                }
                urunIcerikDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün içerik {urunIcerik.Adi} ekleme işlemi.";

                _logger.DoLog(logDTO);

                //Map
                GreenHouseMapper mapper = new GreenHouseMapper();

                return mapper.MapUrunIcerikUrunIcerikAdminDTO(urunIcerik);
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün içerik {urunIcerikAdminDTO.Adi} ekleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw ex;
            }
        }

        /// <summary>
        /// Updates the product content info
        /// </summary>
        /// <param name="urunIcerikAdminDTO">Update information</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns>true if successful</returns>
        /// <exception cref="ExistsException">Thrown when a different product with the updated name exists if the name is updated</exception>
        public bool UrunIcerikGuncelleAdmin(UrunIcerikAdminDTO urunIcerikAdminDTO, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Update;
            logDTO.MethodName = "UrunIcerikGuncelleAdmin";

            try
            {
                ProDAL<UrunIcerik> urunIcerikDAL = new ProDAL<UrunIcerik>();

                UrunIcerik nameCheck = urunIcerikDAL.GetByFirst(x => x.Adi.ToLower() == urunIcerikAdminDTO.Adi.ToLower() && x.Id != urunIcerikAdminDTO.Id);

                if (nameCheck != null)
                    throw new ExistsException("Güncellemeye çalıştığınız isimde bir ürün mevcut.");

                UrunIcerik urunIcerik = urunIcerikDAL.GetByID(urunIcerikAdminDTO.Id);

                urunIcerik.Adi = urunIcerikAdminDTO.Adi;
                urunIcerik.Aciklama = urunIcerikAdminDTO.Aciklama;
                urunIcerik.RiskSeviyeId = (int)urunIcerikAdminDTO.RiskSeviyeId;
                urunIcerik.ModifiedBy = currentUserId;
                urunIcerik.ModifiedDate = DateTime.Now;

                urunIcerikDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün içerik {urunIcerik.Adi} güncelleme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün içerik {urunIcerikAdminDTO.Adi} güncelleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw ex;
            }
        }

        /// <summary>
        /// Soft erases the product content
        /// </summary>
        /// <param name="urunIcerikId">Product content to be erased</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns>true if successful</returns>
        public bool UrunIcerikSilAdmin(int urunIcerikId, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Erase;
            logDTO.MethodName = "KullaniciSilAdmin";

            try
            {
                ProDAL<UrunIcerik> urunicerikDAL = new ProDAL<UrunIcerik>();
                UrunIcerik urunIcerik = urunicerikDAL.GetByID(urunIcerikId);

                urunIcerik.isActive = false;
                urunIcerik.ModifiedBy = currentUserId;
                urunIcerik.ModifiedDate = DateTime.Now;

                urunicerikDAL.SaveMyChanges();

                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün içerik {urunIcerikId} ID silme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün içerik {urunIcerikId} ID silme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// Gets basic product content info
        /// </summary>
        /// <param name="currentUserId">User who called the method</param>
        /// <returns>List of UrunIcerikSimpleListDTO</returns>
        public List<UrunIcerikSimpleListDTO> GetAllIcerikForListing(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetAllIcerikForListing";

            try
            {
                ProDAL<UrunIcerik> uiDal = new ProDAL<UrunIcerik>();

                List<UrunIcerik> urunIceriks = uiDal.GetBy(ui => ui.isActive);

                List<UrunIcerikSimpleListDTO> urunIcerikSimpleListDTOs = new List<UrunIcerikSimpleListDTO>();

                GreenHouseMapper mapper = new GreenHouseMapper();
                foreach (var urunIcerik in urunIceriks)
                {
                    urunIcerikSimpleListDTOs.Add(mapper.MapUrunIcerikUrunIcerikSimpleDTO(urunIcerik));
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün içerikleri çekme işlemi.";

                _logger.DoLog(logDTO);

                return urunIcerikSimpleListDTOs;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün içerikleri çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw ex;
            }
        }

        /// <summary>
        /// Gets the information necessary for the product content page
        /// </summary>
        /// <param name="icerikId">Id of the product content whose information we need</param>
        /// <param name="currentUserId">User who is using the application, will be used for blacklist check</param>
        /// <returns>UrunIcerikDTO</returns>
        public UrunIcerikDTO GetIcerikDTOById(int icerikId, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetIcerikDTOById";

            try
            {
                UrunIcerikDTO urunIcerikDTO = null;

                using (MyDbContext db = new MyDbContext())
                {
                    urunIcerikDTO = (from ui in db.UrunIcerik
                                     where ui.Id == icerikId
                                     join uui in db.UrunUrunIcerik on ui.Id equals uui.UrunIcerikId into lJoin
                                     from lj in lJoin.DefaultIfEmpty()
                                     join kuikl in db.KullaniciUrunIcerikKaraListe on ui.Id equals kuikl.UrunIcerikId into lJoin2
                                     from lj2 in lJoin2.DefaultIfEmpty()
                                     group new { ui.Adi, ui.Aciklama, ui.RiskSeviyeId, lj, lj2 } by ui.Id into grp
                                     select new UrunIcerikDTO()
                                     {
                                         Id = icerikId,
                                         Adi = grp.Select(x => x.Adi).FirstOrDefault(),
                                         RiskSeviyeId = (Commons.RiskSeviye)grp.Select(x => x.RiskSeviyeId).FirstOrDefault(),
                                         Aciklama = grp.Select(x => x.Aciklama).FirstOrDefault(),
                                         KaraListede = grp.Where(x => x.lj2 != null && x.lj2.CreatedBy == currentUserId && x.lj2.isActive).Count() > 0,
                                         UsedInCount = grp.Where(x => x.lj != null && x.lj.isActive).Select(x => x.lj.UrunId).Distinct().Count()
                                     }).FirstOrDefault();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün içerik {icerikId} ID çekme işlemi.";

                _logger.DoLog(logDTO);

                return urunIcerikDTO;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün içerik {icerikId} ID çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw ex;
            }
        }
    }
}
