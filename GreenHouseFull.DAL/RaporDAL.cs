using GreenHouseFull.Common;
using GreenHouseFull.Core.Context;
using GreenHouseFull.DTO;
using GreenHouseFull.DTO.RaporDTOs;
using GreenHouseFull.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DAL
{
    public class RaporDAL
    {
        private ILogger<LogDTO> _logger;

        /// <summary>
        /// Uses NLogLogger to log to the specified file.
        /// </summary>
        /// <param name="logFileName">Name of the log file. Only Name.</param>
        public RaporDAL(string logFileName = "Rapor_Log")
        {
            _logger = new NLogLogger<LogDTO>(logFileName);
        }

        public RaporDAL(ILogger<LogDTO> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Hangi ürünün kaç maddesi var
        /// </summary>
        /// <returns></returns>
        public List<UrunUrunIcerikAdetDTO> GetAllUrunUrunIcerikAdetRapor(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetAllUrunUrunIcerikAdetRapor";

            try
            {
                List<UrunUrunIcerikAdetDTO> list = null;
                using (MyDbContext db = new MyDbContext())
                {
                    list = (from u in db.Urun
                            join uui in db.UrunUrunIcerik on u.Id equals uui.UrunId
                            group new { u.Adi, uui } by u.Id into grp
                            select new UrunUrunIcerikAdetDTO()
                            {
                                UrunAdi = grp.Select(x => x.Adi).FirstOrDefault(),
                                IcerikAdet = grp.Count()
                            }).ToList();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı hangi ürünün kaç maddesi olduğunu alma işlemi.";

                _logger.DoLog(logDTO);

                return list;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız hangi ürünün kaç maddesi olduğunu alma işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Örnek: ethanol geçen ürünlerin listesi
        /// </summary>
        /// <param name="urunIcerikAdi"></param>
        /// <returns></returns>
        public List<UrunIcerikKullananUrunlerDTO> GetUrunIcerikKullananlarRapor(string urunIcerikAdi, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetUrunIcerikKullananlarRapor";

            try
            {
                List<UrunIcerikKullananUrunlerDTO> urunIcerikDTO = null;

                using (MyDbContext db = new MyDbContext())
                {
                    urunIcerikDTO = (from ui in db.UrunIcerik
                                     where ui.Adi == urunIcerikAdi
                                     join uui in db.UrunUrunIcerik on ui.Id equals uui.UrunIcerikId
                                     join u in db.Urun on uui.UrunId equals u.Id
                                     group new { ui.Adi, u } by ui.Id into grp
                                     select new UrunIcerikKullananUrunlerDTO
                                     {
                                         IcerikAdi = grp.Select(x => x.Adi).FirstOrDefault(),
                                         UrunAdi = grp.Select(x => x.u.Adi).ToList()
                                     }).ToList();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı {urunIcerikAdi} adlı içeriği kullanan ürünleri çekme işlemi.";

                _logger.DoLog(logDTO);

                return urunIcerikDTO;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız {urunIcerikAdi} adlı içeriği kullanan ürünleri çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Hangi kullanıcının kaç ürün girişi var
        /// </summary>
        /// <returns></returns>
        public List<KullaniciUrunGirisSayiDTO> GetAllKullaniciUrunSayisi(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetAllKullaniciUrunSayisi";

            try
            {
                List<KullaniciUrunGirisSayiDTO> kullaniciUrunSayiDTO = null;
                using (MyDbContext db = new MyDbContext())
                {
                    kullaniciUrunSayiDTO = (from u in db.Urun
                                            join k in db.Kullanici on u.CreatedBy equals k.Id
                                            group k.KullaniciAdi by u.CreatedBy into grp
                                            select new KullaniciUrunGirisSayiDTO()
                                            {
                                                KullaniciAdi = grp.Select(x => x).FirstOrDefault(),
                                                UrunSayisi = grp.Count()
                                            }).ToList();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı kullanıcıları ürün sayılarını alma işlemi.";

                _logger.DoLog(logDTO);

                return kullaniciUrunSayiDTO;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız kullanıcıları ürün sayılarını alma işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// adminin onayı girilmemiş kaç ürünü var aylık
        /// </summary>
        /// <returns></returns>
        public int GetAylikBekleyenOnaylarRapor(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetAylikBekleyenOnaylarRapor";

            try
            {
                ProDAL<UrunOnayDurum> uodDAL = new ProDAL<UrunOnayDurum>();
                int deger = uodDAL.GetBy(x => x.OnayDurumId == (int)Commons.OnayDurum.Beklemede && x.CreatedDate.Month == DateTime.Now.Month).ToList().Count();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı aylık beklenen onaylar sayısı alma işlemi.";

                _logger.DoLog(logDTO);

                return deger;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız aylık beklenen onaylar sayısı alma işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Örnek: ethanol içeriği kaç kişinin favorisinde karalistesinde (PARTIALLY DONE? Analysis doesn't say contents can be added to favorites)
        /// </summary>
        /// <param name="urunIcerikAdi"></param>
        /// <returns></returns>
        public int GetIcerikKaralisteSayi(string urunIcerikAdi, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetIcerikKaralisteSayi";

            try
            {
                int result = 0;

                //Kaç kişinin kara listesinde
                using (MyDbContext db = new MyDbContext())
                {
                    result = (from ui in db.UrunIcerik
                              where ui.Adi == urunIcerikAdi
                              join kuikl in db.KullaniciUrunIcerikKaraListe on ui.Id equals kuikl.UrunIcerikId
                              select kuikl.CreatedBy).ToList().Count();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı {urunIcerikAdi} adlı içeriğin karalisteye alınma sayısını alma işlemi.";

                _logger.DoLog(logDTO);

                return result;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız {urunIcerikAdi} adlı içeriğin karalisteye alınma sayısını alma işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// en riskli ürünler
        /// </summary>
        /// <returns></returns>
        public List<UrunEnCokRiskSayilariDTO> GetEnCokRiskUrunSayilari(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetEnCokRiskUrunSayilari";

            try
            {
                List<UrunEnCokRiskSayilariDTO> urunEnCokRiskSayilari = null;
                using (MyDbContext db = new MyDbContext())
                {
                    urunEnCokRiskSayilari = (from u in db.Urun
                                             join uui in db.UrunUrunIcerik on u.Id equals uui.UrunId
                                             join ui in db.UrunIcerik on uui.UrunIcerikId equals ui.Id
                                             where ui.RiskSeviyeId == 3 || ui.RiskSeviyeId == 4
                                             group new { u.Adi, ui.RiskSeviyeId } by u.Id into grp
                                             select new UrunEnCokRiskSayilariDTO()
                                             {
                                                 UrunAdi = grp.Select(x => x.Adi).FirstOrDefault(),
                                                 RiskliSayi = grp.Where(x => x.RiskSeviyeId == (int)Commons.RiskSeviye.Riskli).Count(),
                                                 OrtaRiskliSayi = grp.Where(x => x.RiskSeviyeId == (int)Commons.RiskSeviye.Orta_Riskli).Count(),
                                             }).OrderByDescending(x => x.RiskliSayi).ThenByDescending(x => x.OrtaRiskliSayi).ToList();

                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı en riskli ürünleri alma işlemi.";

                _logger.DoLog(logDTO);

                return urunEnCokRiskSayilari;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız en riskli ürünleri alma işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// en favori ürünler
        /// </summary>
        /// <returns></returns>
        public List<UrunFavoriSayiDTO> GetAllUrunEnFavoriSayi(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetAllUrunEnFavoriSayi";

            try
            {
                List<UrunFavoriSayiDTO> urunFavoriSayiDTO = null;
                using (MyDbContext db = new MyDbContext())
                {
                    urunFavoriSayiDTO = (from u in db.Urun
                                         join kufl in db.KullaniciUrunFavoriListe on u.Id equals kufl.UrunId
                                         group u.Adi by u.Id into grp
                                         orderby grp.Count() descending
                                         select new UrunFavoriSayiDTO()
                                         {
                                             UrunAdi = grp.Select(x => x).FirstOrDefault(),
                                             FavoriSayisi = grp.Count()
                                         }).ToList();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı en favori ürünleri alma işlemi.";

                _logger.DoLog(logDTO);

                return urunFavoriSayiDTO;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız en favori ürünleri alma işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// en çok favori ürünler neler ilk 3
        /// </summary>
        /// <returns></returns>
        public List<UrunFavoriSayiDTO> GetAllUrunEnFavoriSayiIlk3(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetAllUrunEnFavoriSayiIlk3";

            try
            {
                List<UrunFavoriSayiDTO> urunFavoriSayiDTO = null;
                using (MyDbContext db = new MyDbContext())
                {
                    urunFavoriSayiDTO = (from u in db.Urun
                                         join kufl in db.KullaniciUrunFavoriListe on u.Id equals kufl.UrunId
                                         group u.Adi by u.Id into grp
                                         orderby grp.Count() descending
                                         select new UrunFavoriSayiDTO()
                                         {
                                             UrunAdi = grp.Select(x => x).FirstOrDefault(),
                                             FavoriSayisi = grp.Count()
                                         }).Take(3).ToList(); ;
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı en çok favoriye eklenen ilk 3 ürünü alma işlemi.";

                _logger.DoLog(logDTO);

                return urunFavoriSayiDTO;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız en çok favoriye eklenen ilk 3 ürünü alma işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// en çok allerjen(kara liste?) yapan ürünler neler
        /// </summary>
        /// <returns></returns>
        public List<UrunAlerjenSayiDTO> GetUrunAlerjenSayi(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetUrunAlerjenSayi";

            try
            {
                List<UrunAlerjenSayiDTO> urunAlerjenSayiDTOs = new List<UrunAlerjenSayiDTO>();
                using (MyDbContext db = new MyDbContext())
                {
                    urunAlerjenSayiDTOs = (from u in db.Urun
                                           join uui in db.UrunUrunIcerik on u.Id equals uui.UrunId
                                           join kuikl in db.KullaniciUrunIcerikKaraListe on uui.UrunIcerikId equals kuikl.UrunIcerikId
                                           group new { u.Adi, kuikl.UrunIcerikId } by u.Id into grp
                                           select new UrunAlerjenSayiDTO()
                                           {
                                               UrunAdi = grp.Select(x => x.Adi).FirstOrDefault(),
                                               AlerjenSayi = grp.Distinct().Count()
                                           }).OrderByDescending(x => x.AlerjenSayi).ToList();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı en çok alerjen yapan ürünleri alma işlemi.";

                _logger.DoLog(logDTO);

                return urunAlerjenSayiDTOs;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız en çok alerjen yapan ürünleri alma işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// en az riski olan ürünler neler kaçı favoride
        /// </summary>
        /// <returns></returns>
        public List<UrunEnAzRiskSayilariFavoriDTO> GetEnAzRiskUrunFavori(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetEnAzRiskUrunFavori";

            try
            {
                //en az risk riski olan ürünler neler kaçı favoride (bir üründe 11 temiz içerik varsa ve 1 üründe 1 temiz içerik varsa 11 içerikli daha temiz)
                List<UrunEnAzRiskSayilariFavoriDTO> urunEnAzRiskSayilari = null;
                using (MyDbContext db = new MyDbContext())
                {
                    urunEnAzRiskSayilari = (from u in db.Urun
                                            join uui in db.UrunUrunIcerik on u.Id equals uui.UrunId
                                            join ui in db.UrunIcerik on uui.UrunIcerikId equals ui.Id
                                            where ui.RiskSeviyeId == 1 || ui.RiskSeviyeId == 2
                                            join kufl in db.KullaniciUrunFavoriListe on u.Id equals kufl.UrunId into favoriLJjoin
                                            from flj in favoriLJjoin.DefaultIfEmpty()
                                            group new { u.Adi, IcerikId = ui.Id, ui.RiskSeviyeId, flj } by u.Id into grp
                                            select new UrunEnAzRiskSayilariFavoriDTO()
                                            {
                                                UrunAdi = grp.Select(x => x.Adi).FirstOrDefault(),
                                                TemizRiskSayi = grp.Where(x => x.RiskSeviyeId == (int)Commons.RiskSeviye.Temiz).Select(x => x.IcerikId).Distinct().Count(),
                                                AzRiskSayi = grp.Where(x => x.RiskSeviyeId == (int)Commons.RiskSeviye.Az_Riskli).Select(x => x.IcerikId).Distinct().Count(),
                                                Favoride = grp.Any(x => x.flj != null)
                                            }).OrderByDescending(x => x.TemizRiskSayi).ThenBy(x => x.AzRiskSayi).ToList();

                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı en az riski olup favoriye eklenen ürünleri alma işlemi.";

                _logger.DoLog(logDTO);

                return urunEnAzRiskSayilari;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız en az riski olup favoriye eklenen ürünleri alma işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// en fazla riskli ürün tutan ilk 3 kullanıcı kim
        /// </summary>
        /// <returns></returns>
        public List<KullaniciRiskliUrunDTO> GetKullaniciRiskliUrunTop3(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetKullaniciRiskliUrunTop3";

            try
            {
                List<KullaniciRiskliUrunDTO> kullaniciRiskliUrunDTOs = null;
                using (MyDbContext db = new MyDbContext())
                {
                    kullaniciRiskliUrunDTOs = (from u in db.Urun
                                               join k in db.Kullanici on u.CreatedBy equals k.Id
                                               join uui in db.UrunUrunIcerik on u.Id equals uui.UrunId
                                               join ui in db.UrunIcerik on uui.UrunIcerikId equals ui.Id
                                               where ui.RiskSeviyeId == (int)Commons.RiskSeviye.Riskli
                                               group new { k.KullaniciAdi, u.Id } by k.Id into grp
                                               orderby grp.Count() descending
                                               select new KullaniciRiskliUrunDTO
                                               {
                                                   KullaniciAdi = grp.Select(x => x.KullaniciAdi).FirstOrDefault(),
                                                   RiskliUrunSayisi = grp.Distinct().Count()
                                               }).Take(3).ToList();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı en fazla riskli ürün tutan ilk 3 kullanıcıyı alma işlemi.";

                _logger.DoLog(logDTO);

                return kullaniciRiskliUrunDTOs;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız en fazla riskli ürün tutan ilk 3 kullanıcıyı alma işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// en çok ürün giren kullanıcıların ilk 5 kullanıcı adı ve email
        /// </summary>
        /// <returns></returns>
        public List<KullaniciEnCokUrunSayisiDTO> GetEnCokUrunKullaniciAdiEmailTop5(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetEnCokUrunKullaniciAdiEmailTop5";

            try
            {
                List<KullaniciEnCokUrunSayisiDTO> kullaniciUrunSayiDTO = null;
                using (MyDbContext db = new MyDbContext())
                {
                    kullaniciUrunSayiDTO = (from u in db.Urun
                                            join k in db.Kullanici on u.CreatedBy equals k.Id
                                            group new { k.KullaniciAdi, k.Email } by u.CreatedBy into grp
                                            orderby grp.Count() descending
                                            select new KullaniciEnCokUrunSayisiDTO()
                                            {
                                                KullaniciAdi = grp.Select(x => x.KullaniciAdi).FirstOrDefault(),
                                                Email = grp.Select(x => x.Email).FirstOrDefault(),
                                                UrunSayisi = grp.Count()
                                            }).Take(5).ToList();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı en çok ürün ekleyen ilk 5 kullanıcıyı alma işlemi.";

                _logger.DoLog(logDTO);

                return kullaniciUrunSayiDTO;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız en çok ürün ekleyen ilk 5 kullanıcıyı alma işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// en çok maddesi olan ürün (son 10 ürün) içerik sayılarıyla
        /// </summary>
        /// <returns></returns>
        public List<UrunIcerikSayilariDTO> GetUrunIcerikSayilarLast10(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetUrunIcerikSayilarLast10";

            try
            {
                List<UrunIcerikSayilariDTO> urunIcerikSayilari = null;
                using (MyDbContext db = new MyDbContext())
                {
                    urunIcerikSayilari = (from u in db.Urun
                                          join uui in db.UrunUrunIcerik on u.Id equals uui.UrunId
                                          join ui in db.UrunIcerik on uui.UrunIcerikId equals ui.Id
                                          group new { u.Adi, ui.RiskSeviyeId } by u.Id into grp
                                          orderby grp.Count() ascending //since we need most component last 10 if we order by ascending we can take first 10
                                          select new UrunIcerikSayilariDTO()
                                          {
                                              UrunAdi = grp.Select(x => x.Adi).FirstOrDefault(),
                                              RiskSeviyeSayilari = new List<RiskSeviyeAdetDTO>()
                                          {
                                              new RiskSeviyeAdetDTO()
                                              {
                                                  Seviye = Commons.RiskSeviye.Temiz,
                                                  Adet = grp.Where(x => x.RiskSeviyeId == (int) Commons.RiskSeviye.Temiz).Count()
                                              },
                                              new RiskSeviyeAdetDTO()
                                              {
                                                  Seviye = Commons.RiskSeviye.Az_Riskli,
                                                  Adet = grp.Where(x => x.RiskSeviyeId == (int) Commons.RiskSeviye.Az_Riskli).Count()
                                              },
                                              new RiskSeviyeAdetDTO()
                                              {
                                                  Seviye = Commons.RiskSeviye.Orta_Riskli,
                                                  Adet = grp.Where(x => x.RiskSeviyeId == (int) Commons.RiskSeviye.Orta_Riskli).Count()
                                              },
                                              new RiskSeviyeAdetDTO()
                                              {
                                                  Seviye = Commons.RiskSeviye.Riskli,
                                                  Adet = grp.Where(x => x.RiskSeviyeId == (int) Commons.RiskSeviye.Riskli).Count()
                                              }
                                          }
                                          }).Take(10).ToList();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı en çok içeriği olan son 10 ürünü alma işlemi.";

                _logger.DoLog(logDTO);

                return urunIcerikSayilari;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız en çok içeriği olan son 10 ürünü alma işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// bu ay kara listeye / favoriye alınan ürünler (PARTIALLY DONE? Analysis doesn't say products can be added to blacklist)
        /// </summary>
        /// <returns></returns>
        public List<string> GetAylikFavoriAlinanUrunler(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetAylikFavoriAlinanUrunler";

            try
            {
                //Favorite products
                List<string> urunIsimleri = null;
                using (MyDbContext db = new MyDbContext())
                {
                    urunIsimleri = (from kufl in db.KullaniciUrunFavoriListe
                                    join u in db.Urun on kufl.UrunId equals u.Id
                                    where kufl.CreatedDate.Month == DateTime.Now.Month
                                    select u.Adi).Distinct().ToList();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı aylık favoriye alınan ürünleri alma işlemi.";

                _logger.DoLog(logDTO);

                return urunIsimleri;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız aylık favoriye alınan ürünleri alma işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// kimin kaç tane kara listeli ürünü kaçtane favori ürünleri var (PARTIALLY DONE? Analysis doesn't say products can be added to blacklist)
        /// </summary>
        /// <returns></returns>
        public List<KullaniciFavoriUrunSayiDTO> GetKullaniciFavoriSayi(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetKullaniciFavoriSayi";

            try
            {
                List<KullaniciFavoriUrunSayiDTO> kullaniciFavorisDTO = null;
                using (MyDbContext db = new MyDbContext())
                {
                    kullaniciFavorisDTO = (from k in db.Kullanici
                                           join kfl in db.KullaniciFavoriListe on k.Id equals kfl.CreatedBy into lJoin
                                           from lj in lJoin.DefaultIfEmpty()
                                           join kufl in db.KullaniciUrunFavoriListe on lj.Id equals kufl.ListeId into lJoin2
                                           from lj2 in lJoin2.DefaultIfEmpty()
                                           group new { k.KullaniciAdi, lj2 } by k.Id into grp
                                           select new KullaniciFavoriUrunSayiDTO()
                                           {
                                               KullaniciAdi = grp.Select(x => x.KullaniciAdi).FirstOrDefault(),
                                               FavoriUrunSayi = grp.Where(x => x.lj2 != null).Count()
                                           }).ToList();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı kullanıcı favori sayıları alma işlemi.";

                _logger.DoLog(logDTO);

                return kullaniciFavorisDTO;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız kullanıcı favori sayıları alma işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// kaç kullanıcı kaç sistem admin yada diğerleri var
        /// </summary>
        /// <returns></returns>
        public List<KullaniciTipSayiDTO> GetAllKullanciTipSayi(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetAllKullanciTipSayi";

            try
            {
                List<KullaniciTipSayiDTO> kullaniciTipSayiDTO = null;
                using (MyDbContext db = new MyDbContext())
                {
                    kullaniciTipSayiDTO = (from r in db.Rol
                                           join k in db.Kullanici on r.Id equals k.RolId into firstJoin
                                           from d in firstJoin.DefaultIfEmpty()
                                           group new { d.KullaniciAdi } by r.Adi into grp
                                           select new KullaniciTipSayiDTO()
                                           {
                                               RolAdi = grp.Key,
                                               KullaniciSayisi = grp.Where(x => x.KullaniciAdi != null).Count()
                                           }).ToList();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı kullanıcı tip sayılarını alma işlemi.";

                _logger.DoLog(logDTO);

                return kullaniciTipSayiDTO;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız kullanıcı tip sayılarını alma işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }
    }
}
