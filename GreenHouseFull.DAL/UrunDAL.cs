using GreenHouseFull.Common;
using GreenHouseFull.Core.Context;
using GreenHouseFull.DTO;
using GreenHouseFull.ExceptionHandling;
using GreenHouseFull.Log;
using GreenHouseFull.Mapping;
using GreenHouseFull.Validation;
using Microsoft.SqlServer.Server;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace GreenHouseFull.DAL
{
    public class UrunDAL
    {
        private ILogger<LogDTO> _logger;

        /// <summary>
        /// Uses NLogLogger to log to the specified file.
        /// </summary>
        /// <param name="logFileName">Name of the log file. Only Name.</param>
        public UrunDAL(string logFileName = "Urun_Log")
        {
            _logger = new NLogLogger<LogDTO>(logFileName);
        }

        public UrunDAL(ILogger<LogDTO> logger)
        {
            _logger = logger;
        }

        #region Admin

        /// <summary>
        /// Gets all products basic info
        /// </summary>
        /// <param name="currentUserId">User of the application</param>
        /// <returns>List of UrunSimpleListDTO</returns>
        public List<UrunSimpleListDTO> GetAllUrun(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetAllUrun";

            try
            {
                ProDAL<Urun> urunDAL = new ProDAL<Urun>();
                GreenHouseMapper mapper = new GreenHouseMapper();

                List<UrunSimpleListDTO> urunSimpleListDTOs = urunDAL.GetBy(x => x.isActive).Select(x => mapper.MapUrunUrunSimpleListDTO(x)).ToList();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün bilgileri çekme işlemi.";

                _logger.DoLog(logDTO);

                return urunSimpleListDTOs;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün bilgileri çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }

        }

        /// <summary>
        /// Gets the information of the specified product for admin page
        /// </summary>
        /// <param name="urunId">Urun Id whose information we need</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns>UrunAdminDTO</returns>
        public UrunAdminDTO GetSelectedUrunProperties(int urunId, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetSelectedUrunProperties";

            try
            {
                UrunAdminDTO urunAdminDTO = null;

                using (MyDbContext db = new MyDbContext())
                {
                    urunAdminDTO = (from u in db.Urun
                                    where u.Id == urunId
                                    join kat in db.Kategori on u.KategoriId equals kat.Id
                                    join ur in db.Uretici on u.UreticiId equals ur.Id
                                    join uui in db.UrunUrunIcerik on u.Id equals uui.UrunId
                                    where uui.isActive
                                    join ui in db.UrunIcerik on uui.UrunIcerikId equals ui.Id
                                    group new
                                    {
                                        u.Barkod,
                                        u.CreatedBy,
                                        u.Adi,
                                        u.KullaniciGoster,
                                        u.Icerik,
                                        u.OnYuz,
                                        u.ArkaYuz,
                                        KategoriAdi = kat.Adi,
                                        UreticiAdi = ur.Adi,
                                        ui
                                    } by u.Id into grp
                                    select new UrunAdminDTO()
                                    {
                                        Barkod = grp.Select(x => x.Barkod).FirstOrDefault(),
                                        Adi = grp.Select(x => x.Adi).FirstOrDefault(),
                                        KategoriAdi = grp.Select(x => x.KategoriAdi).FirstOrDefault(),
                                        UreticiAdi = grp.Select(x => x.UreticiAdi).FirstOrDefault(),
                                        KullaniciGoster = grp.Select(x => x.KullaniciGoster).FirstOrDefault(),
                                        EkleyenKullanici = (from k in db.Kullanici where k.Id == grp.Select(x => x.CreatedBy).FirstOrDefault() select k.KullaniciAdi).FirstOrDefault(),
                                        Icerik = grp.Select(x => x.Icerik).FirstOrDefault(),
                                        OnYuz = grp.Select(x => x.OnYuz).FirstOrDefault(),
                                        ArkaYuz = grp.Select(x => x.ArkaYuz).FirstOrDefault(),
                                        UrunIceriks = grp.Select(x => new UrunIcerikSimpleListDTO()
                                        {
                                            Id = x.ui.Id,
                                            Adi = x.ui.Adi,
                                        }).Distinct().ToList()
                                    }).FirstOrDefault();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün {urunAdminDTO.Adi} bilgileri çekme işlemi.";

                _logger.DoLog(logDTO);

                return urunAdminDTO;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün {urunId} ID bilgileri çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Adds new product. For admin usage.
        /// </summary>
        /// <param name="urunEkleDTO">New product info</param>
        /// <returns>UrunSimpleListDTO</returns>
        /// <exception cref="ModelNotValidException">Thrown when there are problems with the information</exception>
        public UrunSimpleListDTO UrunEkleAdmin(UrunEkleDTO urunEkleDTO)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = urunEkleDTO.CreatedBy;
            logDTO.OperationType = IslemTur.Add;
            logDTO.MethodName = "UrunEkleAdmin";

            try
            {
                UrunEkleValidation urunEkleValidation = new UrunEkleValidation(urunEkleDTO);

                if (!urunEkleValidation.IsValid)
                    throw new ModelNotValidException(urunEkleValidation.ValidationMessages);

                GreenHouseMapper mapper = new GreenHouseMapper();
                ProDAL<Urun> urunDAL = new ProDAL<Urun>();
                Urun barkodCheck = urunDAL.GetByFirst(x => x.Barkod == urunEkleDTO.Barkod);
                if (barkodCheck != null)
                {
                    if (barkodCheck.isActive)
                        throw new ExistsException("Bu barkod da bir ürün sistemde mevcut.");
                    else
                    {
                        //Barcode exists but inactive so make it active with new info
                        using (TransactionScope scope = new TransactionScope())
                        {
                            barkodCheck.isActive = true;
                            barkodCheck.Adi = urunEkleDTO.Adi;
                            barkodCheck.Icerik = urunEkleDTO.Icerik;
                            barkodCheck.OnYuz = urunEkleDTO.OnYuz;
                            barkodCheck.ArkaYuz = urunEkleDTO.ArkaYuz;
                            barkodCheck.KullaniciGoster = urunEkleDTO.KullaniciGoster;
                            barkodCheck.KategoriId = urunEkleDTO.KategoriId;
                            barkodCheck.UreticiId = urunEkleDTO.UreticiId;
                            barkodCheck.ModifiedBy = urunEkleDTO.ModifiedBy;
                            barkodCheck.ModifiedDate = urunEkleDTO.ModifiedDate;

                            IcerikEkleKaldir(barkodCheck.Id, urunEkleDTO.UrunIcerikIds, urunEkleDTO.ModifiedBy);

                            urunDAL.SaveMyChanges();

                            scope.Complete();
                        }

                        //Logging
                        logDTO.OperationResult = IslemSonuc.Success;
                        logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün {barkodCheck.Adi} ekleme işlemi.";

                        _logger.DoLog(logDTO);

                        return mapper.MapUrunUrunSimpleListDTO(barkodCheck);
                    }
                }
                else
                {
                    //Create new product
                    Urun newU = mapper.MapUrunEkleDTOUrun(urunEkleDTO);

                    using (TransactionScope scope = new TransactionScope())
                    {
                        ProDAL<Urun> uDal = new ProDAL<Urun>();

                        uDal.Add(newU);
                        uDal.SaveMyChanges();

                        int newUrunId = newU.Id;

                        ProDAL<UrunUrunIcerik> uuiDal = new ProDAL<UrunUrunIcerik>();
                        foreach (int urunIcerikId in urunEkleDTO.UrunIcerikIds)
                        {
                            uuiDal.Add(new UrunUrunIcerik()
                            {
                                UrunId = newUrunId,
                                UrunIcerikId = urunIcerikId,
                                isActive = true,
                                CreatedBy = newU.CreatedBy,
                                ModifiedBy = newU.ModifiedBy,
                                CreatedDate = DateTime.Now,
                                ModifiedDate = DateTime.Now,
                            });
                        }
                        uuiDal.SaveMyChanges();

                        ProDAL<UrunOnayDurum> uodDal = new ProDAL<UrunOnayDurum>();
                        uodDal.Add(new UrunOnayDurum()
                        {
                            TakipNumarasi = Guid.NewGuid(),
                            UrunId = newUrunId,
                            OnayDurumId = (int)Commons.OnayDurum.Kabul_Edildi,
                            Aciklama = "Admin tarafından eklendiği için otomatik olarak onaylanmıştır.",
                            isActive = true,
                            CreatedBy = newU.CreatedBy,
                            ModifiedBy = newU.ModifiedBy,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                        });
                        uodDal.SaveMyChanges();

                        scope.Complete();
                    }

                    //Logging
                    logDTO.OperationResult = IslemSonuc.Success;
                    logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün {newU.Adi} ekleme işlemi.";

                    _logger.DoLog(logDTO);

                    return mapper.MapUrunUrunSimpleListDTO(newU);
                }
            }
            catch (ModelNotValidException ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün {urunEkleDTO.Adi} ekleme işlemi. Hata mesajı: " + string.Join(" ; ", ex.ValidationMessages);

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün {urunEkleDTO.Adi} ekleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Updates product info. For admin usage.
        /// </summary>
        /// <param name="urunGuncelleDTO">New information</param>
        /// <param name="guncellenecekId">ProductId to be updated</param>
        /// <param name="currentUserId"></param>
        /// <returns>true if successful</returns>
        /// <exception cref="ExistsException">Thrown when same information with the same barcode exists</exception>
        public bool UrunGuncelleAdmin(UrunGuncelleDTO urunGuncelleDTO, int guncellenecekId, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Update;
            logDTO.MethodName = "UrunGuncelleAdmin";

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    ProDAL<Urun> urunDAL = new ProDAL<Urun>();
                    Urun urunToUpdate = null;

                    Urun barkodCheck = urunDAL.GetByFirst(x => x.Barkod == urunGuncelleDTO.Barkod);
                    if (barkodCheck != null)
                    {
                        if (barkodCheck.Id != guncellenecekId)
                            throw new ExistsException("Bu barkodda bir ürün sistemde mevcut.");
                        else
                            urunToUpdate = barkodCheck;
                    }

                    if (urunToUpdate == null)
                        urunToUpdate = urunDAL.GetByID(guncellenecekId);

                    urunToUpdate.Barkod = urunGuncelleDTO.Barkod;
                    urunToUpdate.Adi = urunGuncelleDTO.Adi;
                    urunToUpdate.Icerik = urunGuncelleDTO.Icerik;
                    urunToUpdate.OnYuz = urunGuncelleDTO.OnYuz;
                    urunToUpdate.ArkaYuz = urunGuncelleDTO.ArkaYuz;
                    urunToUpdate.KullaniciGoster = urunGuncelleDTO.KullaniciGoster;
                    urunToUpdate.KategoriId = urunGuncelleDTO.KategoriId;
                    urunToUpdate.UreticiId = urunGuncelleDTO.UreticiId;
                    urunToUpdate.isActive = true;
                    urunToUpdate.ModifiedBy = currentUserId;
                    urunToUpdate.ModifiedDate = DateTime.Now;

                    IcerikEkleKaldir(urunToUpdate.Id, urunGuncelleDTO.UrunIcerikIds, currentUserId);

                    urunDAL.SaveMyChanges();

                    //Logging
                    logDTO.OperationResult = IslemSonuc.Success;
                    logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün {urunToUpdate.Adi} güncelleme işlemi.";

                    _logger.DoLog(logDTO);

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün {guncellenecekId} ID güncelleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }

            return true;
        }

        /// <summary>
        /// Soft erases the product. For admin usage.
        /// </summary>
        /// <param name="urunId">Product Id to be erased</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns>true if successful</returns>
        public bool UrunSilAdmin(int urunId, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Erase;
            logDTO.MethodName = "UrunSilAdmin";

            try
            {
                ProDAL<Urun> urunDAL = new ProDAL<Urun>();

                Urun urun = urunDAL.GetByID(urunId);

                urun.isActive = false;
                urun.ModifiedBy = currentUserId;
                urun.ModifiedDate = DateTime.Now;

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün {urunId} ID silme işlemi.";

                _logger.DoLog(logDTO);

                urunDAL.SaveMyChanges();
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün {urunId} ID silme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }

            return true;
        }

        /// <summary>
        /// Adds or removes product content from product's contents
        /// </summary>
        /// <param name="urunId">Product Id to add or remove product content from</param>
        /// <param name="iceriks">Product contents the product needs to contain</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns>true if successful</returns>
        public bool IcerikEkleKaldir(int urunId, List<int> iceriks, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Update;
            logDTO.MethodName = "IcerikEkleKaldir";

            try
            {
                ProDAL<UrunUrunIcerik> urunUrunIcerikDAL = new ProDAL<UrunUrunIcerik>();
                List<UrunUrunIcerik> urunUrunIceriks = urunUrunIcerikDAL.GetBy(x => x.UrunId == urunId);

                foreach (var urunUrunIcerik in urunUrunIceriks)
                {
                    //Remove existing ones if not in the new list
                    if (!iceriks.Contains(urunUrunIcerik.UrunIcerikId))
                    {
                        urunUrunIcerik.isActive = false;
                        urunUrunIcerik.ModifiedBy = currentUserId;
                        urunUrunIcerik.ModifiedDate = DateTime.Now;
                        iceriks.Remove(urunUrunIcerik.UrunIcerikId);
                    }
                    //Set the active if they are in both lists
                    else
                    {
                        urunUrunIcerik.isActive = true;
                        urunUrunIcerik.ModifiedBy = currentUserId;
                        urunUrunIcerik.ModifiedDate = DateTime.Now;
                        iceriks.Remove(urunUrunIcerik.UrunIcerikId);
                    }
                }

                //Add new ones
                foreach (var newIcerik in iceriks)
                {
                    urunUrunIcerikDAL.Add(new UrunUrunIcerik()
                    {
                        UrunId = urunId,
                        UrunIcerikId = newIcerik,
                        isActive = true,
                        CreatedBy = currentUserId,
                        ModifiedBy = currentUserId,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                    });
                }

                urunUrunIcerikDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün {urunId} ID için içerik güncelleme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün {urunId} ID için içerik güncelleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        #endregion

        /// <summary>
        /// Gets product matching the search parameters
        /// </summary>
        /// <param name="urunAdi">Name of the product to be searched</param>
        /// <returns>List of UrunSimpleListDTO</returns>
        public List<UrunSimpleListDTO> SearchProductName(string urunAdi, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "SearchProductName";

            try
            {
                List<UrunSimpleListDTO> urunAdiAraDTOs = new List<UrunSimpleListDTO>();

                using (MyDbContext db = new MyDbContext())
                {
                    urunAdiAraDTOs = (from u in db.Urun
                                      where u.isActive && u.Adi.ToLower().Contains(urunAdi.ToLower())
                                      join uod in db.UrunOnayDurum on u.Id equals uod.UrunId
                                      where uod.OnayDurumId == (int)Commons.OnayDurum.Kabul_Edildi
                                      group new { u.Id, u.Adi } by u.Id into grp
                                      select new UrunSimpleListDTO()
                                      {
                                          Id = grp.Select(x => x.Id).FirstOrDefault(),
                                          Adi = grp.Select(x => x.Adi).FirstOrDefault()
                                      }).ToList();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün adı {urunAdi} ile arama işlemi.";

                _logger.DoLog(logDTO);

                return urunAdiAraDTOs;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün adı {urunAdi} ile arama işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }

        }

        /// <summary>
        /// Gets the product matching the barcode
        /// </summary>
        /// <param name="barkod">Barcode to find the product</param>
        /// <param name="currentUserId">User calling the function, necessary for blacklist check</param>
        /// <returns>null if no product oherwise UrunDTO</returns>
        /// <exception cref="ExistsException">Thrown when product is not approved</exception>
        public UrunDTO SearchBarcode(string barkod, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "SearchBarcode";

            try
            {
                ProDAL<Urun> uDal = new ProDAL<Urun>();
                Urun urun = uDal.GetByFirst(u => u.isActive && u.Barkod == new Guid(barkod));

                //Check if such an active barcode exists
                if (urun == null)
                {
                    //Logging
                    logDTO.OperationResult = IslemSonuc.Error;
                    logDTO.OperationNote = $"Kullanıcı tarafından başarısız barkod {barkod} arama işlemi. Nedeni böyle bi barkod yok veya aktif değil.";

                    _logger.DoLog(logDTO);

                    return null;
                }

                ProDAL<UrunOnayDurum> urunOnayDAL = new ProDAL<UrunOnayDurum>();
                bool approvedProduct = urunOnayDAL.GetByFirst(x => x.UrunId == urun.Id && x.OnayDurumId == (int)Commons.OnayDurum.Kabul_Edildi) != null;

                //Check if it is approved
                if (!approvedProduct)
                    throw new ExistsException("Ürün mevcut ancak henüz onaylanmamış.");

                //Get the information for the product page
                UrunDTO urunDTO = GetUrunDTO(urun.Id, currentUserId);

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı barkod {barkod} arama işlemi.";

                _logger.DoLog(logDTO);

                return urunDTO;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız barkod {barkod} arama işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Gets information necessary for the product page
        /// </summary>
        /// <param name="urunId">Id of product whose information we need</param>
        /// <param name="currentUserId">User calling the function, necessary for blacklist check</param>
        /// <returns>null if no product otherwise UrunDTO</returns>
        public UrunDTO GetUrunDTO(int urunId, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetUrunDTO";

            try
            {
                KullaniciGecmisAramaDAL gecmisAramaDAL = new KullaniciGecmisAramaDAL();
                gecmisAramaDAL.AddToUserSearchHistory(currentUserId, urunId);

                UrunDTO urunDTO = new UrunDTO();
                using (MyDbContext db = new MyDbContext())
                {
                    urunDTO = (from u in db.Urun
                               where u.Id == urunId
                               join kat in db.Kategori on u.KategoriId equals kat.Id
                               join ur in db.Uretici on u.UreticiId equals ur.Id
                               join uui in db.UrunUrunIcerik on u.Id equals uui.UrunId
                               join ui in db.UrunIcerik on uui.UrunIcerikId equals ui.Id
                               join k in db.Kullanici on u.CreatedBy equals k.Id
                               join kuikl in db.KullaniciUrunIcerikKaraListe on new { uuiID = uui.UrunIcerikId, userId = currentUserId } equals new { uuiID = kuikl.UrunIcerikId, userId = kuikl.CreatedBy } into karaLJoin
                               from klj in karaLJoin.DefaultIfEmpty()
                               join kufl in db.KullaniciUrunFavoriListe on new { uID = u.Id, userId = currentUserId } equals new { uID = kufl.UrunId, userId = kufl.CreatedBy } into favoriLJoin
                               from flj in favoriLJoin.DefaultIfEmpty()
                               group new
                               {
                                   u.CreatedBy,
                                   u.Adi,
                                   u.KullaniciGoster,
                                   u.OnYuz,
                                   u.ArkaYuz,
                                   KategoriAdi = kat.Adi,
                                   UreticiAdi = ur.Adi,
                                   k.KullaniciAdi,
                                   ui,
                                   klj,
                                   flj
                               } by u.Id into grp
                               select new UrunDTO()
                               {
                                   Id = grp.Key,
                                   Adi = grp.Select(x => x.Adi).FirstOrDefault(),
                                   KategoriAdi = grp.Select(x => x.KategoriAdi).FirstOrDefault(),
                                   UreticiAdi = grp.Select(x => x.UreticiAdi).FirstOrDefault(),
                                   KullaniciAdi = grp.Select(x => x.KullaniciGoster).FirstOrDefault() == false ? "" : grp.Select(x => x.KullaniciAdi).FirstOrDefault(),
                                   OnYuz = grp.Select(x => x.OnYuz).FirstOrDefault(),
                                   ArkaYuz = grp.Select(x => x.ArkaYuz).FirstOrDefault(),
                                   IcerikList = grp.Select(x => new UrunIcerikUrunListeDTO()
                                   {
                                       Id = x.ui.Id,
                                       Adi = x.ui.Adi,
                                       RiskSeviyeId = (Commons.RiskSeviye)x.ui.RiskSeviyeId,
                                       KaraListede = x.klj != null
                                   }).Distinct().ToList(),
                                   Favoride = grp.Any(x => x.flj != null)
                               }).FirstOrDefault();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün {urunId} ID bilgisi çekme işlemi.";

                _logger.DoLog(logDTO);

                return urunDTO;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün {urunId} ID bilgisi çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="urunEkleDTO">Information of the new product</param>
        /// <returns>true if successful</returns>
        /// <exception cref="ModelNotValidException">Thrown when new product information has problems</exception>
        public bool UrunEkle(UrunEkleDTO urunEkleDTO)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = urunEkleDTO.CreatedBy;
            logDTO.OperationType = IslemTur.Add;
            logDTO.MethodName = "UrunEkle";

            try
            {
                //Validate DTO
                UrunEkleValidation urunEkleValidation = new UrunEkleValidation(urunEkleDTO);
                CheckExistingBarkod(urunEkleValidation, urunEkleDTO.Barkod);

                if (!urunEkleValidation.IsValid)
                    throw new ModelNotValidException(urunEkleValidation.ValidationMessages);

                GreenHouseMapper mapper = new GreenHouseMapper();
                Urun newU = mapper.MapUrunEkleDTOUrun(urunEkleDTO);

                using (TransactionScope scope = new TransactionScope())
                {
                    ProDAL<Urun> uDal = new ProDAL<Urun>();

                    uDal.Add(newU);
                    uDal.SaveMyChanges();

                    int newUrunId = newU.Id;

                    ProDAL<UrunUrunIcerik> uuiDal = new ProDAL<UrunUrunIcerik>();
                    foreach (int urunIcerikId in urunEkleDTO.UrunIcerikIds)
                    {
                        uuiDal.Add(new UrunUrunIcerik()
                        {
                            UrunId = newUrunId,
                            UrunIcerikId = urunIcerikId,
                            isActive = true,
                            CreatedBy = newU.CreatedBy,
                            ModifiedBy = newU.ModifiedBy,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                        });
                    }
                    uuiDal.SaveMyChanges();

                    ProDAL<UrunOnayDurum> uodDal = new ProDAL<UrunOnayDurum>();
                    uodDal.Add(new UrunOnayDurum()
                    {
                        TakipNumarasi = Guid.NewGuid(),
                        UrunId = newUrunId,
                        OnayDurumId = (int)Commons.OnayDurum.Beklemede,
                        Aciklama = "İncelenmeyi bekliyor.",
                        isActive = true,
                        CreatedBy = newU.CreatedBy,
                        ModifiedBy = newU.ModifiedBy,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                    });
                    uodDal.SaveMyChanges();

                    scope.Complete();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı ürün {urunEkleDTO.Adi} ekleme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (ModelNotValidException ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün {urunEkleDTO.Adi} ekleme işlemi. Hata mesajı: " + string.Join(" ; ", ex.ValidationMessages);

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız ürün {urunEkleDTO.Adi} ekleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Checks the existence of product with same barcode
        /// </summary>
        /// <param name="urunEkleValidation">Validation object to append errors</param>
        /// <param name="barkod">Barcode to be searched</param>
        /// <returns>true if successful</returns>
        private bool CheckExistingBarkod(UrunEkleValidation urunEkleValidation, Guid barkod)
        {
            ProDAL<Urun> uDal = new ProDAL<Urun>();
            bool notExists = uDal.GetBy(x => x.Barkod == barkod).Count == 0;

            if (!notExists)
            {
                urunEkleValidation.IsValid = false;
                urunEkleValidation.ValidationMessages.Add("BU barkodlu bir ürün mevcut.");
            }


            return uDal.GetBy(x => x.Barkod == barkod).Count == 0;
        }
    }
}
