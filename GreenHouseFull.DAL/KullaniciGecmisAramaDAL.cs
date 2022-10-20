using GreenHouseFull.Core.Context;
using GreenHouseFull.DTO;
using GreenHouseFull.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace GreenHouseFull.DAL
{
    public class KullaniciGecmisAramaDAL
    {
        private ILogger<LogDTO> _logger;

        /// <summary>
        /// Uses NLogLogger to log to the specified file.
        /// </summary>
        /// <param name="logFileName">Name of the log file. Only Name.</param>
        public KullaniciGecmisAramaDAL(string logFileName = "KullaniciGecmisArama_Log")
        {
            _logger = new NLogLogger<LogDTO>(logFileName);
        }

        public KullaniciGecmisAramaDAL(ILogger<LogDTO> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Soft Erases the search history of the user
        /// </summary>
        /// <param name="currentUserId">User Id who the search history belongs</param>
        /// <returns>true if successful</returns>
        public bool EraseSearchHistory(int currentUserId) //Soft erasing - change isActive = 1 to isActive = 0
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Erase;
            logDTO.MethodName = "EraseSearchHistory";

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    ProDAL<KullaniciGecmisArama> gecmisDal = new ProDAL<KullaniciGecmisArama>();

                    //Find the past searches of the user
                    List<KullaniciGecmisArama> gecmisAramas = gecmisDal.GetBy(x => x.isActive && x.CreatedBy == currentUserId);

                    //Soft erase items in the past searches
                    foreach (var item in gecmisAramas)
                    {
                        item.isActive = false;
                        item.ModifiedBy = currentUserId;
                        item.ModifiedDate = DateTime.Now;
                    }

                    gecmisDal.SaveMyChanges();

                    //Logging
                    logDTO.OperationResult = IslemSonuc.Success;
                    logDTO.OperationNote = $"Kullanıcı tarafından başarılı arama geçmişi silme işlemi.";

                    _logger.DoLog(logDTO);

                    scope.Complete();
                }

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız arama geçmişi silme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Adds the item to the past searches of the user
        /// </summary>
        /// <param name="currentUserId"></param>
        /// <param name="urunId"></param>
        /// <returns>true if successful</returns>
        public bool AddToUserSearchHistory(int currentUserId, int urunId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Add;
            logDTO.MethodName = "AddToUserSearchHistory";

            try
            {
                ProDAL<KullaniciGecmisArama> gecmisDal = new ProDAL<KullaniciGecmisArama>();

                //Check if this urunId and currentUserId exists
                KullaniciGecmisArama gecmisArama = gecmisDal.GetByFirst(x => x.CreatedBy == currentUserId && x.UrunId == urunId);

                if (gecmisArama == null)
                {
                    //Product not in past searches so add it
                    gecmisDal.Add(new KullaniciGecmisArama()
                    {
                        CreatedBy = currentUserId,
                        UrunId = urunId,
                        ModifiedBy = currentUserId,
                        isActive = true,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    });
                }
                else
                {
                    //Product is in past searches but inactive so make it active
                    gecmisArama.isActive = true;
                    gecmisArama.ModifiedBy = currentUserId;
                    gecmisArama.ModifiedDate = DateTime.Now;
                }

                gecmisDal.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı geçmişe ürün {urunId} ID ekleme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız geçmişe ürün {urunId} ID ekleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }


        /// <summary>
        /// Gets the past searches of the user
        /// </summary>
        /// <param name="currentUserId">User Id we need to get the past searches</param>
        /// <returns>List of UrunSimpleListDTO</returns>
        public List<UrunSimpleListDTO> GetUserSearchHistory(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetUserSearchHistory";

            try
            {
                List<UrunSimpleListDTO> urunListDTO = null;
                using (MyDbContext db = new MyDbContext())
                {
                    urunListDTO = (from kga in db.KullaniciGecmisArama
                                   where kga.CreatedBy == currentUserId && kga.isActive
                                   join u in db.Urun on kga.UrunId equals u.Id
                                   select new UrunSimpleListDTO()
                                   {
                                       Id = u.Id,
                                       Adi = u.Adi
                                   }).ToList();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün geçmişi çekme işlemi.";

                _logger.DoLog(logDTO);

                return urunListDTO;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün geçmişi çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Erases specified product from users search history
        /// </summary>
        /// <param name="urunId">Product to be erased</param>
        /// <param name="currentUserId">Owner of the search history</param>
        /// <returns>true if successful</returns>
        public bool EraseFromSearchHistory(int urunId, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Erase;
            logDTO.MethodName = "EraseFromSearchHistory";

            try
            {
                ProDAL<KullaniciGecmisArama> gecmisDAL = new ProDAL<KullaniciGecmisArama>();

                KullaniciGecmisArama gecmisArama = gecmisDAL.GetByFirst(x => x.UrunId == urunId && x.CreatedBy == currentUserId);
                gecmisArama.isActive = false;
                gecmisArama.ModifiedBy = currentUserId;
                gecmisArama.ModifiedDate = DateTime.Now;

                gecmisDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün {urunId} ID sini geçmişten silme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün {urunId} ID sini geçmişten silme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Erases products from search history if they are added to the list before the specified date
        /// </summary>
        /// <param name="date">Search history before this date will be erased</param>
        /// <param name="currentUserId">Owner of the search history</param>
        /// <returns>List of erased Ids</returns>
        public List<int> EraseSearchesBeforeDate(DateTime date, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Erase;
            logDTO.MethodName = "EraseFromSearchHistory";

            List<int> erasedIds = new List<int>();

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    ProDAL<KullaniciGecmisArama> gecmisDAL = new ProDAL<KullaniciGecmisArama>();

                    //ModifiedDate instead of CreatedDate because of soft erase
                    List<KullaniciGecmisArama> gecmisAramaList = gecmisDAL.GetBy(x => x.ModifiedDate <= date && x.CreatedBy == currentUserId && x.isActive);
                    foreach (var gecmisArama in gecmisAramaList)
                    {
                        erasedIds.Add(gecmisArama.UrunId);

                        gecmisArama.isActive = false;
                        gecmisArama.ModifiedBy = currentUserId;
                        gecmisArama.ModifiedDate = DateTime.Now;
                    }

                    gecmisDAL.SaveMyChanges();

                    scope.Complete();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı {date} tarihinden önce geçmişe eklenmiş ürünleri geçmişten silme işlemi.";

                _logger.DoLog(logDTO);

                return erasedIds;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız {date} tarihinden önce geçmişe eklenmiş ürünleri geçmişten silme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }
    }
}
