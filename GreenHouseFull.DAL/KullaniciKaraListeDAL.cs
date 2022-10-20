using GreenHouseFull.Core.Context;
using GreenHouseFull.DTO;
using GreenHouseFull.ExceptionHandling;
using GreenHouseFull.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DAL
{
    public class KullaniciKaraListeDAL
    {
        private ILogger<LogDTO> _logger;

        /// <summary>
        /// Uses NLogLogger to log to the specified file.
        /// </summary>
        /// <param name="logFileName">Name of the log file. Only Name.</param>
        public KullaniciKaraListeDAL(string logFileName = "KullaniciKaraListe_Log")
        {
            _logger = new NLogLogger<LogDTO>(logFileName);
        }

        public KullaniciKaraListeDAL(ILogger<LogDTO> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Erase product content from the blacklist of the user. For admin usage.
        /// </summary>
        /// <param name="urunIcerikId">Product content to be erased from the blacklist</param>
        /// <param name="userId">Owner of the blacklist</param>
        /// <param name="adminId">Admin</param>
        /// <returns>true if successful</returns>
        public bool EraseFromBlacklist(int urunIcerikId, int userId, int? adminId = null)
        {
            int idOfUserPerformingOperation = adminId ?? userId;
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = idOfUserPerformingOperation;
            logDTO.OperationType = IslemTur.Erase;
            logDTO.MethodName = "EraseFromBlacklistAdmin";

            try
            {
                ProDAL<KullaniciUrunIcerikKaraListe> karaListeDAL = new ProDAL<KullaniciUrunIcerikKaraListe>();

                KullaniciUrunIcerikKaraListe karaListedekiIcerik = karaListeDAL.GetByFirst(x => x.UrunIcerikId == urunIcerikId && x.CreatedBy == userId);

                karaListedekiIcerik.isActive = false;
                karaListedekiIcerik.ModifiedBy = idOfUserPerformingOperation;
                karaListedekiIcerik.ModifiedDate = DateTime.Now;

                karaListeDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                if (userId == idOfUserPerformingOperation)
                    logDTO.OperationNote = $"Kullanıcı tarafından başarılı karalisteden ürün içerik {urunIcerikId} ID kaldırma işlemi.";
                else
                    logDTO.OperationNote = $"Kullanıcı tarafından başarılı kullanıcı {userId} ID nin karalistesinden ürün içerik {urunIcerikId} ID kaldırma işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                if (userId == idOfUserPerformingOperation)
                    logDTO.OperationNote = $"Kullanıcı tarafından başarısız karalisteden ürün içerik {urunIcerikId} ID kaldırma işlemi. Hata mesajı: " + ex.Message;
                else
                    logDTO.OperationNote = $"Kullanıcı tarafından başarısız kullanıcı {userId} ID nin karalistesinden ürün içerik {urunIcerikId} ID kaldırma işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Adds product content to the blacklist of the user
        /// </summary>
        /// <param name="urunIcerikId">Product content to be added to the blacklist</param>
        /// <param name="userId">Owner of the blacklist</param>
        /// <param name="adminId">Id of admin if an admin is doing this for another user</param>
        /// <returns>true if successful</returns>
        /// <exception cref="ExistsException">Thrown when product content is already in the blacklist</exception>
        public bool AddIcerikToKaraList(int urunIcerikId, int userId, int? adminId = null)
        {
            int idOfUserPerformingOperation = adminId ?? userId;
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = idOfUserPerformingOperation;
            logDTO.OperationType = IslemTur.Erase;
            logDTO.MethodName = "KullaniciSilAdmin";

            try
            {
                ProDAL<KullaniciUrunIcerikKaraListe> karaListeDAL = new ProDAL<KullaniciUrunIcerikKaraListe>();
                KullaniciUrunIcerikKaraListe listedeIcerik = karaListeDAL.GetByFirst(x => x.UrunIcerikId == urunIcerikId && x.CreatedBy == userId);

                if (listedeIcerik != null)
                {
                    if (listedeIcerik.isActive)
                        throw new ExistsException("Bu içerik zaten kara listenizde.");
                    else
                    {
                        listedeIcerik.isActive = true;
                        listedeIcerik.ModifiedBy = idOfUserPerformingOperation;
                        listedeIcerik.ModifiedDate = DateTime.Now;
                    }
                }
                else
                {
                    karaListeDAL.Add(new KullaniciUrunIcerikKaraListe()
                    {
                        UrunIcerikId = urunIcerikId,
                        CreatedBy = userId,
                        ModifiedBy = idOfUserPerformingOperation,
                        isActive = true,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    });
                }

                karaListeDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                if (userId == idOfUserPerformingOperation)
                    logDTO.OperationNote = $"Kullanıcı tarafından başarılı karalisteye ürün içerik {urunIcerikId} ID ekleme işlemi.";
                else
                    logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün içerik {urunIcerikId} ID sini kullanıcı {userId} ID nin kara listesine ekleme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                if (userId == idOfUserPerformingOperation)
                    logDTO.OperationNote = $"Kullanıcı tarafından başarısız karalisteye ürün içerik {urunIcerikId} ID ekleme işlemi. Hata mesajı: " + ex.Message;
                else
                    logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün içerik {urunIcerikId} ID sini kullanıcı {userId} ID nin kara listesine ekleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Gets the blacklist of the user
        /// </summary>
        /// <param name="currentUserId">Owner of the blacklist</param>
        /// <returns>List of UrunIcerikSimpleListDTO</returns>
        public List<UrunIcerikSimpleListDTO> GetKullaniciKaraListe(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetKullaniciKaraListe";

            try
            {
                List<UrunIcerikSimpleListDTO> icerikDTO = null;
                using (MyDbContext db = new MyDbContext())
                {
                    icerikDTO = (from kuikl in db.KullaniciUrunIcerikKaraListe
                                 where kuikl.CreatedBy == currentUserId && kuikl.isActive
                                 join ui in db.UrunIcerik on kuikl.UrunIcerikId equals ui.Id
                                 where ui.isActive
                                 select new UrunIcerikSimpleListDTO()
                                 {
                                     Id = ui.Id,
                                     Adi = ui.Adi
                                 }).ToList();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı karaliste çekme işlemi.";

                _logger.DoLog(logDTO);

                return icerikDTO;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız karaliste çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }
    }
}
