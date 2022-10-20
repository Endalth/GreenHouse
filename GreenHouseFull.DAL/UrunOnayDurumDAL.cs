using GreenHouseFull.Common;
using GreenHouseFull.Core.Context;
using GreenHouseFull.DTO;
using GreenHouseFull.Log;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DAL
{
    public class UrunOnayDurumDAL
    {
        private ILogger<LogDTO> _logger;

        /// <summary>
        /// Uses NLogLogger to log to the specified file.
        /// </summary>
        /// <param name="logFileName">Name of the log file. Only Name.</param>
        public UrunOnayDurumDAL(string logFileName = "UrunOnayDurum_Log")
        {
            _logger = new NLogLogger<LogDTO>(logFileName);
        }

        public UrunOnayDurumDAL(ILogger<LogDTO> logger)
        {
            _logger = logger;
        }

        #region Admin

        /// <summary>
        /// Updates the approval status of the product. For admin usage.
        /// </summary>
        /// <param name="guncelleDTO">Approval status of the product that needs to be updated</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns>true if successful</returns>
        public bool UrunOnayDurumGuncelleAdmin(UrunOnayDurumGuncelleDTO guncelleDTO, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Update;
            logDTO.MethodName = "UrunOnayDurumGuncelleAdmin";

            try
            {
                ProDAL<UrunOnayDurum> urunOnayDAL = new ProDAL<UrunOnayDurum>();

                UrunOnayDurum urunOnayDurum = urunOnayDAL.GetByID(guncelleDTO.TakipNumarasi);
                urunOnayDurum.OnayDurumId = (int)guncelleDTO.OnayDurumId;
                urunOnayDurum.Aciklama = guncelleDTO.Aciklama;
                urunOnayDurum.ModifiedBy = currentUserId;
                urunOnayDurum.ModifiedDate = DateTime.Now;

                urunOnayDAL.SaveMyChanges();

                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün onay durum {guncelleDTO.TakipNumarasi} takip numarası güncelleme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün onay durum {guncelleDTO.TakipNumarasi} takip numarası güncelleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Soft erases the product approval status. For admin usage.
        /// </summary>
        /// <param name="silinecekId">Approval status to be erased</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns></returns>
        public bool UrunOnayDurumSilAdmin(Guid silinecekId, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Erase;
            logDTO.MethodName = "UrunOnayDurumSilAdmin";

            try
            {
                ProDAL<UrunOnayDurum> urunOnayDAL = new ProDAL<UrunOnayDurum>();

                UrunOnayDurum urunOnayDurum = urunOnayDAL.GetByID(silinecekId);
                urunOnayDurum.isActive = false;
                urunOnayDurum.ModifiedBy = currentUserId;
                urunOnayDurum.ModifiedDate = DateTime.Now;

                urunOnayDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün onay durum takip numarası {silinecekId} silme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün onay durum takip numarası {silinecekId} silme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Gets the product approval status
        /// </summary>
        /// <param name="currentUserId">User who is calling the method</param>
        /// <returns>List of UrunOnayListDTO</returns>
        public List<UrunOnayListDTO> GetUrunOnayList(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetUrunOnayList";

            try
            {
                List<UrunOnayListDTO> urunOnayDTOs = null;

                using (MyDbContext db = new MyDbContext())
                {
                    urunOnayDTOs = (from uod in db.UrunOnayDurum
                                    where uod.isActive
                                    join k in db.Kullanici on uod.CreatedBy equals k.Id
                                    where k.isActive
                                    join u in db.Urun on uod.UrunId equals u.Id
                                    where u.isActive
                                    select new UrunOnayListDTO()
                                    {
                                        TakipNumarasi = uod.TakipNumarasi,
                                        UrunAdi = u.Adi,
                                        OnayDurumId = (Commons.OnayDurum)uod.OnayDurumId,
                                        Aciklama = uod.Aciklama,
                                        UrunuEkleyen = k.KullaniciAdi
                                    }).OrderBy(x => x.OnayDurumId).ToList();
                }

                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün onay durum listesi çekme işlemi.";

                _logger.DoLog(logDTO);

                return urunOnayDTOs;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün onay durum listesi çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        #endregion

        /// <summary>
        /// Gets the explanation of the specified tracking number
        /// </summary>
        /// <param name="takipNumarasi">Tracking number to get the explanation of</param>
        /// <param name="currentUserId">User calling the function</param>
        /// <returns>Explanation of the tracking number</returns>
        public string GetUrunOnayAciklama(Guid takipNumarasi, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetUrunOnayAciklama";

            try
            {
                ProDAL<UrunOnayDurum> onayDurumDAL = new ProDAL<UrunOnayDurum>();
                string aciklama = onayDurumDAL.GetByID(takipNumarasi).Aciklama;

                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı {takipNumarasi} ürün onay numarasının açıklamasını çekme işlemi.";

                _logger.DoLog(logDTO);

                return aciklama;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız {takipNumarasi} ürün onay numarasının açıklamasını çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }
    }
}
