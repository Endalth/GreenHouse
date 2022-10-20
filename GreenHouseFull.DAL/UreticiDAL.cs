using GreenHouseFull.Core.Context;
using GreenHouseFull.DTO;
using GreenHouseFull.ExceptionHandling;
using GreenHouseFull.Log;
using GreenHouseFull.Mapping;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DAL
{
    public class UreticiDAL
    {
        private ILogger<LogDTO> _logger;

        /// <summary>
        /// Uses NLogLogger to log to the specified file.
        /// </summary>
        /// <param name="logFileName">Name of the log file. Only Name.</param>
        public UreticiDAL(string logFileName = "Uretici_Log")
        {
            _logger = new NLogLogger<LogDTO>(logFileName);
        }

        public UreticiDAL(ILogger<LogDTO> logger)
        {
            _logger = logger;
        }

        #region Admin

        /// <summary>
        /// Adds new producer. For admin usage.
        /// </summary>
        /// <param name="adi">Name of the producer</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns>UreticiSimpleListDTO</returns>
        /// <exception cref="ExistsException">Thrown when a producer with the same name exists</exception>
        public UreticiSimpleListDTO UreticiEkleAdmin(string adi, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Add;
            logDTO.MethodName = "UreticiEkleAdmin";

            try
            {
                ProDAL<Uretici> ureticiDAL = new ProDAL<Uretici>();

                Uretici uretici = ureticiDAL.GetByFirst(x => x.Adi.ToLower() == adi.ToLower());

                if (uretici != null)
                {
                    if (uretici.isActive)
                        throw new ExistsException("Bu isimde bir üretici mevcut");
                    else
                    {
                        uretici.isActive = true;
                        uretici.ModifiedBy = currentUserId;
                        uretici.ModifiedDate = DateTime.Now;
                    }
                }
                else
                {
                    uretici = new Uretici()
                    {
                        Adi = adi,
                        CreatedBy = currentUserId,
                        ModifiedBy = currentUserId,
                        isActive = true,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    };
                    ureticiDAL.Add(uretici);
                }

                ureticiDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı üretici {adi} ekleme işlemi.";

                _logger.DoLog(logDTO);

                GreenHouseMapper mapper = new GreenHouseMapper();

                return mapper.MapUreticiUreticiSimpleDTO(uretici);
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız üretici {adi} ekleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Updates the producer name
        /// </summary>
        /// <param name="ureticiSimpleListDTO">Producer to be updated</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns>true if successful</returns>
        /// <exception cref="ExistsException">Thrown when same producer name exists</exception>
        public bool UreticiGuncelleAdmin(UreticiSimpleListDTO ureticiSimpleListDTO, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Update;
            logDTO.MethodName = "UreticiGuncelleAdmin";

            try
            {
                ProDAL<Uretici> ureticiDAL = new ProDAL<Uretici>();

                Uretici existsCheck = ureticiDAL.GetByFirst(x => x.Adi.ToLower() == ureticiSimpleListDTO.Adi.ToLower());

                if (existsCheck != null && existsCheck.Id != ureticiSimpleListDTO.Id)
                {
                    if (existsCheck.isActive)
                        throw new ExistsException("Güncellemeye çalıştığınız isimde bir üretici mevcut.");
                    else
                        throw new ExistsException("Güncellemeye çalıştığınız isim sistemde mevcut ancak aktif değil. ");
                }

                Uretici uretici = ureticiDAL.GetByID(ureticiSimpleListDTO.Id);
                uretici.isActive = true;
                uretici.Adi = ureticiSimpleListDTO.Adi;
                uretici.ModifiedBy = currentUserId;
                uretici.ModifiedDate = DateTime.Now;

                ureticiDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı üretici {ureticiSimpleListDTO.Adi} güncelleme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız üretici {ureticiSimpleListDTO.Id} güncelleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Soft erases the specified producer. For admin usage.
        /// </summary>
        /// <param name="ureticiId">Producer to be erased</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns>true if successful</returns>
        public bool UreticiSilAdmin(int ureticiId, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Erase;
            logDTO.MethodName = "UreticiSilAdmin";

            try
            {
                ProDAL<Uretici> ureticiDAL = new ProDAL<Uretici>();

                Uretici uretici = ureticiDAL.GetByID(ureticiId);

                uretici.isActive = false;
                uretici.ModifiedBy = currentUserId;
                uretici.ModifiedDate = DateTime.Now;

                ureticiDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı üretici {ureticiId} ID silme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız üretici {ureticiId} ID silme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        #endregion

        /// <summary>
        /// Gets the Producers
        /// </summary>
        /// <param name="currentUserId">Caller of the method</param>
        /// <returns></returns>
        public List<UreticiSimpleListDTO> GetAllUreticiForListing(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetAllUreticiForListing";

            try
            {
                ProDAL<Uretici> uDal = new ProDAL<Uretici>();

                List<Uretici> ureticis = uDal.GetBy(u => u.isActive);

                List<UreticiSimpleListDTO> ureticiSimpleListDTOs = new List<UreticiSimpleListDTO>();

                GreenHouseMapper mapper = new GreenHouseMapper();
                foreach (var uretici in ureticis)
                {
                    ureticiSimpleListDTOs.Add(mapper.MapUreticiUreticiSimpleDTO(uretici));
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı üreticileri çekme işlemi.";

                _logger.DoLog(logDTO);

                return ureticiSimpleListDTOs;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız üreticileri çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }
    }
}
