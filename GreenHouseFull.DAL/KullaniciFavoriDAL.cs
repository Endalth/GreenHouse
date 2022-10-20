using GreenHouseFull.Core.Context;
using GreenHouseFull.DTO;
using GreenHouseFull.ExceptionHandling;
using GreenHouseFull.Log;
using GreenHouseFull.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DAL
{
    public class KullaniciFavoriDAL
    {
        private ILogger<LogDTO> _logger;

        /// <summary>
        /// Uses NLogLogger to log to the specified file.
        /// </summary>
        /// <param name="logFileName">Name of the log file. Only Name.</param>
        public KullaniciFavoriDAL(string logFileName = "KullaniciFavori_Log")
        {
            _logger = new NLogLogger<LogDTO>(logFileName);
        }

        public KullaniciFavoriDAL(ILogger<LogDTO> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Updates the selected list name. For admin usage
        /// </summary>
        /// <param name="listeId">ListId where the name needs to be updated</param>
        /// <param name="userId">Owner of the list</param>
        /// <param name="newName">New name of the list</param>
        /// <param name="adminId">Id of admin if an admin is doing this for another user</param>
        /// <returns>true if successful</returns>
        /// <exception cref="ExistsException">Thrown when user has a list with the same name</exception>
        public bool ListeAdiGuncelleAdmin(int listeId, int userId, string newName, int? adminId = null)
        {
            int idOfUserPerformingOperation = adminId ?? userId;
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = idOfUserPerformingOperation;
            logDTO.OperationType = IslemTur.Update;
            logDTO.MethodName = "ListeAdiGuncelleAdmin";

            try
            {
                ProDAL<KullaniciFavoriListe> favoriDAL = new ProDAL<KullaniciFavoriListe>();

                KullaniciFavoriListe nameCheck = favoriDAL.GetByFirst(x => x.Adi.ToLower() == newName.ToLower() && x.CreatedBy == userId);

                if (nameCheck != null)
                    throw new ExistsException("Bu isimde bir liste mevcut.");

                KullaniciFavoriListe favoriListe = favoriDAL.GetByID(listeId);

                favoriListe.Adi = newName;
                favoriListe.ModifiedBy = idOfUserPerformingOperation;
                favoriListe.ModifiedDate = DateTime.Now;

                favoriDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı kullanıcı {userId} ID için liste {newName} güncelleme işlemi işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız kullanıcı {userId} ID için liste {listeId} ID güncelleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Soft erases the specified list.
        /// </summary>
        /// <param name="listeId">List Id to be erased</param>
        /// <param name="currentUserId">User calling the method</param>
        /// <returns>true if successful</returns>
        public bool ListeSil(int listeId, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Erase;
            logDTO.MethodName = "ListeSilAdmin";

            try
            {
                ProDAL<KullaniciFavoriListe> favoriDAL = new ProDAL<KullaniciFavoriListe>();

                KullaniciFavoriListe favoriListe = favoriDAL.GetByID(listeId);

                favoriListe.isActive = false;
                favoriListe.ModifiedBy = currentUserId;
                favoriListe.ModifiedDate = DateTime.Now;

                favoriDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı liste {listeId} ID silme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız liste {listeId} ID silme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Soft erases product from the specified list.
        /// </summary>
        /// <param name="listId">List Id where the product will be removed from</param>
        /// <param name="urunId">Product Id to be removed from the list</param>
        /// <param name="currentUserId">User calling the method</param>
        /// <returns>true if successful</returns>
        public bool ListedenUrunKaldir(int listId, int urunId, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Erase;
            logDTO.MethodName = "ListedenUrunKaldirAdmin";

            try
            {
                ProDAL<KullaniciUrunFavoriListe> favoriDAL = new ProDAL<KullaniciUrunFavoriListe>();

                KullaniciUrunFavoriListe kullaniciUrunFavoriListe = favoriDAL.GetByFirst(x => x.ListeId == listId && x.UrunId == urunId);

                kullaniciUrunFavoriListe.isActive = false;
                kullaniciUrunFavoriListe.ModifiedBy = currentUserId;
                kullaniciUrunFavoriListe.ModifiedDate = DateTime.Now;

                favoriDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı liste {listId} ID den ürün {urunId} ID silme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız liste {listId} ID den ürün {urunId} ID silme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Add new list
        /// </summary>
        /// <param name="listName">Name of the list to be added to the user</param>
        /// <param name="userId">User who is creating the list</param>
        /// <param name="adminId">Id of the admin if an admin is doing this for another user</param>
        /// <returns>FavoriListeSimpleListDTO</returns>
        /// <exception cref="ExistsException">Thrown when user has a list with the same name</exception>
        public FavoriListeSimpleListDTO AddNewList(string listName, int userId, int? adminId = null)
        {
            int idOfUserPerformingOperation = adminId ?? userId;

            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = idOfUserPerformingOperation;
            logDTO.OperationType = IslemTur.Add;
            logDTO.MethodName = "AddNewList";

            try
            {
                ProDAL<KullaniciFavoriListe> favoriListeDAL = new ProDAL<KullaniciFavoriListe>();
                KullaniciFavoriListe list = favoriListeDAL.GetByFirst(x => x.CreatedBy == userId && x.Adi.ToLower() == listName.ToLower());

                //Check if the user has a list with the same name
                if (list != null)
                {
                    //There is alist
                    if (list.isActive)
                        throw new ExistsException("Bu isimde bir liste mevcut.");
                    else
                    {
                        //There is a list but inactive so make it active
                        list.Adi = listName;
                        list.isActive = true;
                        list.ModifiedBy = idOfUserPerformingOperation;
                        list.ModifiedDate = DateTime.Now;
                    }
                }
                else
                {
                    list = new KullaniciFavoriListe()
                    {
                        Adi = listName,
                        CreatedBy = userId,
                        ModifiedBy = idOfUserPerformingOperation,
                        isActive = true,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    };

                    favoriListeDAL.Add(list);
                }

                favoriListeDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                if (userId == idOfUserPerformingOperation)
                    logDTO.OperationNote = $"Kullanıcı tarafından başarılı liste {listName} ekleme işlemi.";
                else
                    logDTO.OperationNote = $"Kullanıcı tarafından başarılı kullanıcı {userId} ID için liste {listName} ekleme işlemi.";

                _logger.DoLog(logDTO);

                return new FavoriListeSimpleListDTO()
                {
                    Id = list.Id,
                    ListeAdi = list.Adi
                };
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                if (userId == idOfUserPerformingOperation)
                    logDTO.OperationNote = $"Kullanıcı tarafından başarısız liste {listName} ekleme işlemi. Hata mesajı: " + ex.Message;
                else
                    logDTO.OperationNote = $"Kullanıcı tarafından başarısız kullanıcı {userId} ID için liste {listName} ekleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Adds product to specified favorite list
        /// </summary>
        /// <param name="listId">List Id the product will be added to</param>
        /// <param name="urunId">Product Id which will be added to the list</param>
        /// <param name="userId">Owner of the list</param>
        /// <param name="adminId">Id of the admin who is doing this for another user</param>
        /// <returns>true if successful</returns>
        public bool UrunuFavoriyeEkle(int listId, int urunId, int userId, int? adminId = null)
        {
            int idOfUserPerformingOperation = adminId ?? userId;

            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = idOfUserPerformingOperation;
            logDTO.OperationType = IslemTur.Add;
            logDTO.MethodName = "UrunuFavoriyeEkle";

            try
            {
                ProDAL<KullaniciUrunFavoriListe> urunFavoriDAL = new ProDAL<KullaniciUrunFavoriListe>();

                //Check for same list
                KullaniciUrunFavoriListe newFavori = urunFavoriDAL.GetByFirst(x => x.CreatedBy == userId && x.UrunId == urunId);

                if (newFavori != null)
                {
                    if (newFavori.ListeId == listId && newFavori.isActive)//Exists in the same list
                    {
                        throw new ExistsException("Bu listede bu ürün mevcut.");
                    }
                    else if (newFavori.ListeId == listId && !newFavori.isActive) //Exists in the same list but inactive
                    {
                        newFavori.isActive = true;
                        newFavori.ModifiedBy = idOfUserPerformingOperation;
                        newFavori.ModifiedDate = DateTime.Now;
                    }
                    else if (newFavori.ListeId != listId && newFavori.isActive) //Exists in a different list of the user
                    {
                        throw new ExistsException("Bu ürün kullanıcının başka bir listesinde mevcut.");
                    }
                    else if (newFavori.ListeId != listId && !newFavori.isActive)//Exists in a different list of the user but inactive
                    {
                        //We need to move the Urun to new list but can't modify listId because it is part of the key so we need to delete completely and create a new one

                        urunFavoriDAL.Delete(newFavori);

                        newFavori = new KullaniciUrunFavoriListe()
                        {
                            ListeId = listId,
                            UrunId = urunId,
                            CreatedBy = userId,
                            ModifiedBy = idOfUserPerformingOperation,
                            isActive = true,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        };

                        urunFavoriDAL.Add(newFavori);
                    }
                }
                else
                {
                    //Is not in favorite for this user so add it
                    newFavori = new KullaniciUrunFavoriListe()
                    {
                        ListeId = listId,
                        UrunId = urunId,
                        CreatedBy = userId,
                        ModifiedBy = idOfUserPerformingOperation,
                        isActive = true,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    };

                    urunFavoriDAL.Add(newFavori);
                }

                urunFavoriDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı liste {listId} ID ye ürün {urunId} ID ekleme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız liste {listId} ID ye ürün {urunId} ID ekleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Gets the favorite lists belonging to the user
        /// </summary>
        /// <param name="currentUserId">User Id we need to get the lists</param>
        /// <param name="adminId">Id of the admin who is doing this for another user</param>
        /// <returns>null if empty else list of FavoriListeSimpleListDTO</returns>
        public List<FavoriListeSimpleListDTO> GetUserFavoriteLists(int currentUserId, int? adminId = null)
        {
            int loggingId = adminId ?? currentUserId;
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = loggingId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetUserFavoriteLists";

            try
            {
                ProDAL<KullaniciFavoriListe> dal = new ProDAL<KullaniciFavoriListe>();
                List<KullaniciFavoriListe> favoriListes = dal.GetBy(x => x.CreatedBy == currentUserId && x.isActive);

                if (favoriListes.Count == 0)
                    return null;

                List<FavoriListeSimpleListDTO> favoriListsDTO = new List<FavoriListeSimpleListDTO>();

                GreenHouseMapper mapper = new GreenHouseMapper();
                foreach (var item in favoriListes)
                {
                    favoriListsDTO.Add(mapper.MapToFavoriSimpleListDTO(item));
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı kullanıcı {currentUserId} ID favori listelerini çekme işlemi.";

                _logger.DoLog(logDTO);

                return favoriListsDTO;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız kullanıcı {currentUserId} ID favori listelerini çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Gets the products belonging to the list
        /// </summary>
        /// <param name="listId">List Id to get the products the list contains</param>
        /// <param name="currentUserId">User who ise calling the method</param>
        /// <returns></returns>
        public List<UrunSimpleListDTO> GetProductsBelongingToList(int listId, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetProductsBelongingToList";

            try
            {
                List<UrunSimpleListDTO> urunSimpleListDTOs;

                using (MyDbContext db = new MyDbContext())
                {
                    urunSimpleListDTOs = (from kufl in db.KullaniciUrunFavoriListe
                                          where kufl.ListeId == listId && kufl.isActive
                                          join u in db.Urun on kufl.UrunId equals u.Id
                                          where u.isActive
                                          select new UrunSimpleListDTO()
                                          {
                                              Id = u.Id,
                                              Adi = u.Adi
                                          }).ToList();
                }

                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı liste {listId} ID ye ait ürünleri çekme işlemi.";

                _logger.DoLog(logDTO);

                return urunSimpleListDTOs;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız liste {listId} ID ye ait ürünleri çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }
    }
}
