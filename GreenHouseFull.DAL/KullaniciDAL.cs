using GreenHouseFull.Common;
using GreenHouseFull.Core.Context;
using GreenHouseFull.DTO;
using GreenHouseFull.ExceptionHandling;
using GreenHouseFull.Log;
using GreenHouseFull.Mapping;
using GreenHouseFull.UI;
using GreenHouseFull.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace GreenHouseFull.DAL
{
    public class KullaniciDAL
    {
        private ILogger<LogDTO> _logger;

        /// <summary>
        /// Uses NLogLogger to log to the specified file.
        /// </summary>
        /// <param name="logFileName">Name of the log file. Only Name.</param>
        public KullaniciDAL(string logFileName = "Kullanici_Log")
        {
            _logger = new NLogLogger<LogDTO>(logFileName);
        }
        
        public KullaniciDAL(ILogger<LogDTO> logger)
        {
            _logger = logger;
        }


        #region Admin

        /// <summary>
        /// Gets the active users with their id, names, emails and rols
        /// </summary>
        /// <param name="currentUserId">Id of the user who called the method</param>
        /// <returns>List of KullaniciEmailRolDTO</returns>
        public List<KullaniciEmailRolDTO> GetKullaniciListWithEmailAndRols(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetKullaniciListWithEmailAndRols";

            try
            {
                //Get the active user accounts
                ProDAL<Kullanici> kullaniciDAL = new ProDAL<Kullanici>();
                List<Kullanici> kullanicis = kullaniciDAL.GetBy(x => x.isActive);

                List<KullaniciEmailRolDTO> kullaniciEmailRolDTOs = new List<KullaniciEmailRolDTO>();

                //Map to only get related data
                GreenHouseMapper mapper = new GreenHouseMapper();
                foreach (var kullanici in kullanicis)
                {
                    kullaniciEmailRolDTOs.Add(mapper.MapKullaniciKullaniciEmailRol(kullanici));
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = "Kullanıcı tarafından başarılı kullanıcıları email ve rolleri ile çekme isteği.";

                _logger.DoLog(logDTO);

                return kullaniciEmailRolDTOs;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = "Kullanıcı tarafından başarısız kullanıcıları email ve rolleri ile çekme isteği. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// User registeration. For admin usage.
        /// </summary>
        /// <param name="kayitDTO">User information to be registered</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns>KullaniciEmailRolDTO</returns>
        /// <exception cref="ExistsException">Thrown when same username or email exists</exception>
        public KullaniciEmailRolDTO KullaniciEkleAdmin(KullaniciKayitDTO kayitDTO, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Add;
            logDTO.MethodName = "KullaniciEkleAdmin";

            try
            {
                ProDAL<Kullanici> kullaniciDAL = new ProDAL<Kullanici>();

                string exceptionString = "";

                //Check if name or email exists since they need to be unique
                Kullanici nameCheck = kullaniciDAL.GetByFirst(x => x.KullaniciAdi == kayitDTO.KullaniciAdi);
                if (nameCheck != null)
                    exceptionString += "Böyle bir kullanıcı adı mevcut. ";

                Kullanici emailCheck = kullaniciDAL.GetByFirst(x => x.Email == kayitDTO.Email);
                if (emailCheck != null)
                    exceptionString += "Böyle bir email mevcut. ";

                //If exceptionString is not null and nameCheck and emailCheck is not the same id
                if (exceptionString != "" && (nameCheck == null || emailCheck == null || (nameCheck != null && emailCheck != null && nameCheck.Id != emailCheck.Id)))
                    throw new ExistsException(exceptionString);

                GreenHouseMapper mapper = new GreenHouseMapper();
                Kullanici newUser = null;
                if (nameCheck != null && emailCheck != null && nameCheck.Id == emailCheck.Id)
                {
                    //If name and email exists and they belong to the same user but user is inactive then switch to active
                    nameCheck.isActive = true;
                    nameCheck.Sifre = kayitDTO.Sifre;
                    nameCheck.RolId = (int)kayitDTO.RolId;
                    nameCheck.ModifiedBy = currentUserId;
                    nameCheck.ModifiedDate = DateTime.Now;

                    newUser = nameCheck;
                }
                else
                {
                    //Users doesn't exists then register new user
                    newUser = mapper.MapKullaniciKayitDTOKullanici(kayitDTO);
                    newUser.CreatedBy = currentUserId;
                    newUser.ModifiedBy = currentUserId;

                    newUser = kullaniciDAL.Add(newUser);
                }

                kullaniciDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı kullanıcı {newUser.KullaniciAdi} kayıt işlemi.";

                _logger.DoLog(logDTO);

                return mapper.MapKullaniciKullaniciEmailRol(newUser);
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız kullanıcı {kayitDTO.KullaniciAdi} kayıt işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Updates user information. For admin usage.
        /// </summary>
        /// <param name="kullaniciEmailRolDTO">User information to be updated</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns>true if information updated without problems</returns>
        /// <exception cref="ExistsException">Thrown when same username or email exists for another user</exception>
        public bool KullaniciGuncelleAdmin(KullaniciEmailRolDTO kullaniciEmailRolDTO, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Update;
            logDTO.MethodName = "KullaniciGuncelleAdmin";

            try
            {
                ProDAL<Kullanici> kullaniciDAL = new ProDAL<Kullanici>();

                string exceptionString = "";

                //Check if name or email exists since they need to be unique
                Kullanici nameCheck = kullaniciDAL.GetByFirst(x => x.KullaniciAdi == kullaniciEmailRolDTO.KullaniciAdi && x.Id != kullaniciEmailRolDTO.Id);
                if (nameCheck != null)
                    exceptionString += "Böyle bir kullanıcı adı mevcut. ";

                Kullanici emailCheck = kullaniciDAL.GetByFirst(x => x.Email == kullaniciEmailRolDTO.Email && x.Id != kullaniciEmailRolDTO.Id);
                if (emailCheck != null)
                    exceptionString += "Böyle bir email mevcut. ";

                //If exceptionString is not null and nameCheck and emailCheck is not the same id
                if (exceptionString != "")
                    throw new ExistsException(exceptionString);

                //Update user info
                Kullanici kullanici = kullaniciDAL.GetByID(kullaniciEmailRolDTO.Id);

                kullanici.KullaniciAdi = kullaniciEmailRolDTO.KullaniciAdi;
                kullanici.Email = kullaniciEmailRolDTO.Email;
                kullanici.RolId = (int)kullaniciEmailRolDTO.RolId;
                kullanici.ModifiedBy = currentUserId;
                kullanici.ModifiedDate = DateTime.Now;

                kullaniciDAL.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı kullanıcı {kullanici.KullaniciAdi} bilgisi güncelleme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız kullanıcı {kullaniciEmailRolDTO.KullaniciAdi} bilgisi güncelleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Soft erasing user. Make the account inactive. For admin usage.
        /// </summary>
        /// <param name="userId">User to be erased</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns>true if user successfully erased</returns>
        public bool KullaniciSilAdmin(int userId, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Erase;
            logDTO.MethodName = "KullaniciSilAdmin";

            try
            {
                ProDAL<Kullanici> kullaniciDAL = new ProDAL<Kullanici>();

                Kullanici kullanici = kullaniciDAL.GetByID(userId);

                kullanici.isActive = false;
                kullanici.ModifiedBy = currentUserId;
                kullanici.ModifiedDate = DateTime.Now;

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı kullanıcı {userId} ID silme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız kullanıcı {userId} ID silme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Changes user password. For admin usage.
        /// </summary>
        /// <param name="newPass">New password</param>
        /// <param name="forUserId">User whose password to be changed</param>
        /// <param name="currentUserId">Admin</param>
        /// <returns>true if password changed successfully</returns> 
        public bool AdminChangePasswordFor(string newPass, int forUserId, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Update;
            logDTO.MethodName = "AdminChangePasswordFor";

            try
            {
                ProDAL<Kullanici> db = new ProDAL<Kullanici>();
                Kullanici user = db.GetByID(forUserId);

                user.Sifre = newPass;
                user.ModifiedBy = currentUserId;
                user.ModifiedDate = DateTime.Now;

                db.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı kullanıcı {forUserId} ID şifre güncelleme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız kullanıcı {forUserId} ID şifre güncelleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        #endregion

        /// <summary>
        /// Get every active user account with just id and names.
        /// </summary>
        /// <param name="currentUserId">User who called the method.</param>
        /// <returns>List of KullaniciSimpleListDTO</returns>
        public List<KullaniciSimpleListDTO> GetAllKullanici(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetAllKullanici";

            try
            {
                List<KullaniciSimpleListDTO> kullaniciSimpleListDTOs;

                ProDAL<Kullanici> kullaniciDAL = new ProDAL<Kullanici>();

                //Get active users and map to KullaniSimpleListDTO
                kullaniciSimpleListDTOs = kullaniciDAL.GetBy(x => x.isActive).Select(x => new KullaniciSimpleListDTO()
                {
                    Id = x.Id,
                    KullaniciAdi = x.KullaniciAdi
                }).ToList();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = "Kullanıcı tarafından başarılı kullanıcıları çekme işlemi.";

                _logger.DoLog(logDTO);

                return kullaniciSimpleListDTOs;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = "Kullanıcı tarafından başarısız kullanıcıları çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Gets the profile info of the user.
        /// </summary>
        /// <param name="currentUserId">User Id whose profile we need</param>
        /// <returns>ProfilDTO</returns>
        public ProfilDTO GetProfil(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetProfil";

            try
            {
                ProfilDTO profil = null;

                using (MyDbContext db = new MyDbContext())
                {
                    profil = (from k in db.Kullanici
                              where k.Id == currentUserId
                              join u in db.Urun on k.Id equals u.CreatedBy into lJoin
                              from lj in lJoin.DefaultIfEmpty()
                              group new { k.KullaniciAdi, k.RolId, k.CreatedDate, lj } by k.Id into grp
                              select new ProfilDTO
                              {
                                  KullaniciAdi = grp.Select(x => x.KullaniciAdi).FirstOrDefault(),
                                  RolId = (Commons.Rols)grp.Select(x => x.RolId).FirstOrDefault(),
                                  KayitTarihi = grp.Select(x => x.CreatedDate).FirstOrDefault(),
                                  UrunSayisi = grp.Where(x => x.lj != null && x.lj.isActive).Count()
                              }).FirstOrDefault();
                }

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = "Kullanıcı tarafından başarılı kullanıcı profili çekme işlemi.";

                _logger.DoLog(logDTO);

                return profil;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = "Kullanıcı tarafından başarısız kullanıcı profili çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Updates the email of the user
        /// </summary>
        /// <param name="newEmail">New email</param>
        /// <param name="currentUserId">User Id whose email will be updated</param>
        /// <returns>true if email successfully updated</returns>
        /// <exception cref="SameValueException">Thrown when user enters the same email he is using</exception>
        /// <exception cref="ExistsException">Thrown when newEmail is in use by another user</exception>
        public bool ChangeEmail(string newEmail, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Update;
            logDTO.MethodName = "ChangeEmail";

            try
            {
                ProDAL<Kullanici> db = new ProDAL<Kullanici>();
                Kullanici user = db.GetByID(currentUserId);

                //Check if email is the same
                if (newEmail == user.Email)
                    throw new SameValueException("Güncellemek istediğiniz email şuan ki ile aynı.");

                //Check if there is someone using that email.
                Kullanici userWithEmail = db.GetByFirst(x => x.Email == newEmail && x.Id != currentUserId);
                if (userWithEmail != null)
                    throw new ExistsException("Bu emaili kullanan başka bir kullanıcı mevcut.");

                //Update
                user.Email = newEmail;
                user.ModifiedBy = currentUserId;
                user.ModifiedDate = DateTime.Now;

                db.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı email güncelleme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız email güncelleme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Updates the password of the user
        /// </summary>
        /// <param name="newPass">New password</param>
        /// <param name="currentUserId">User Id whose password will be updated</param>
        /// <returns>true if password successfully updated</returns>
        public bool ChangePassword(string newPass, int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Update;
            logDTO.MethodName = "ChangePassword";

            try
            {
                ProDAL<Kullanici> db = new ProDAL<Kullanici>();
                Kullanici user = db.GetByID(currentUserId);

                //Update
                user.Sifre = newPass;
                user.ModifiedBy = currentUserId;
                user.ModifiedDate = DateTime.Now;

                db.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı şifre değiştirme işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız şifre değiştirme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Change user role to premium
        /// </summary>
        /// <param name="currentUserId">User Id whose role to be updated</param>
        /// <returns>true if successful</returns>
        public bool GoPremium(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Update;
            logDTO.MethodName = "GoPremium";

            try
            {
                ProDAL<Kullanici> db = new ProDAL<Kullanici>();
                Kullanici user = db.GetByID(currentUserId);

                user.RolId = (int)Commons.Rols.Premium;
                user.ModifiedBy = currentUserId;
                user.ModifiedDate = DateTime.Now;

                db.SaveMyChanges();

                //Logging
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı premium üye olma işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız premium üye olma işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// Checks if there is an user matching the login details
        /// </summary>
        /// <param name="kullaniciGirisDTO">Login details</param>
        /// <returns>null if no user, otherwise KullaniciGirisSonucDTO</returns>
        /// <exception cref="ExistsException">Thrown when user exists but inactive</exception> 
        public KullaniciGirisSonucDTO CheckLoginExists(KullaniciGirisDTO kullaniciGirisDTO)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = 0;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "CheckLoginExists";

            try
            {
                ProDAL<Kullanici> kDal = new ProDAL<Kullanici>();
                Kullanici user = kDal.GetByFirst(k => k.KullaniciAdi == kullaniciGirisDTO.KullaniciAdi && k.Sifre == kullaniciGirisDTO.Sifre);

                //No user
                if (user == null)
                {
                    //Logging
                    logDTO.OperationResult = IslemSonuc.Error;
                    logDTO.OperationNote = $"Kullanıcı {kullaniciGirisDTO.KullaniciAdi} tarafından böyle bir kullanıcı adı ve şifre olmadığı için başarısız giriş işlemi.";

                    _logger.DoLog(logDTO);

                    return null;
                }

                //There is an user but inactive account
                if (!user.isActive)
                {
                    logDTO.UserIdToPerformTheOperation = user.Id;
                    throw new ExistsException("Bilgileri girilen kullanıcı mevcut ancak aktif bir hesap değil.");
                }

                GreenHouseMapper mapper = new GreenHouseMapper();
                KullaniciGirisSonucDTO kullanici = mapper.MapKullaniciKullaniciGirisSonucDTO(user);

                //Logging
                logDTO.UserIdToPerformTheOperation = user.Id;
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı {user.KullaniciAdi} tarafından başarılı giriş işlemi.";


                _logger.DoLog(logDTO);

                return kullanici;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı {kullaniciGirisDTO.KullaniciAdi} tarafından başarısız giriş işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw again
                throw;
            }
        }

        /// <summary>
        /// For user registration by user
        /// </summary>
        /// <param name="kullaniciKayitDTO">Registration info</param>
        /// <returns>true if successful</returns>
        /// <exception cref="ModelNotValidException">Thrown when there are problems with registration info</exception>   
        public bool UserRegister(KullaniciKayitDTO kullaniciKayitDTO)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = 0;
            logDTO.OperationType = IslemTur.Add;
            logDTO.MethodName = "KullaniciSilAdmin";

            //Try to insert
            try
            {
                //Validate DTO
                KullaniciKayitValidation kayitValidation = new KullaniciKayitValidation(kullaniciKayitDTO);
                CheckExistingUserNameEmail(kayitValidation, kullaniciKayitDTO.KullaniciAdi, kullaniciKayitDTO.Email);

                if (!kayitValidation.IsValid)
                    throw new ModelNotValidException(kayitValidation.ValidationMessages);

                //Map DTO to Table
                GreenHouseMapper mapper = new GreenHouseMapper();
                Kullanici newK = mapper.MapKullaniciKayitDTOKullanici(kullaniciKayitDTO);

                //Insert
                using (TransactionScope scope = new TransactionScope())
                {
                    ProDAL<Kullanici> kDal = new ProDAL<Kullanici>();
                    kDal.Add(newK);
                    kDal.SaveMyChanges(); //Id almak için bunu çağırmak gerekli

                    newK.CreatedBy = newK.Id;
                    newK.ModifiedBy = newK.Id;

                    kDal.SaveMyChanges();

                    scope.Complete();
                }

                //Logging
                logDTO.UserIdToPerformTheOperation = newK.Id;
                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı adı {newK.KullaniciAdi} ile başarılı kayıt işlemi.";

                _logger.DoLog(logDTO);

                return true;
            }
            catch (ModelNotValidException ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı adı {kullaniciKayitDTO.KullaniciAdi} ile kayıt bilgileri geçersiz olduğu için başarısız kayıt işlemi. Hatalar: " + string.Join(" ; ", ex.ValidationMessages);

                _logger.DoLog(logDTO);

                throw;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı adı {kullaniciKayitDTO.KullaniciAdi} ile başarısız kayıt işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw agan
                throw;
            }
        }

        /// <summary>
        /// Added products list of the specified user.
        /// </summary>
        /// <param name="currentUserId">User whose list we need</param>
        /// <returns>List of UrunListWithStatusDTO</returns>
        public List<UrunListWithStatusDTO> GetProductsBelongingToTheUserWithStatus(int currentUserId)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserIdToPerformTheOperation = currentUserId;
            logDTO.OperationType = IslemTur.Get_Data;
            logDTO.MethodName = "GetProductsBelongingToTheUserWithStatus";

            try
            {
                List<UrunListWithStatusDTO> resultList;
                using (MyDbContext db = new MyDbContext())
                {
                    resultList = (from u in db.Urun
                                  where u.CreatedBy == currentUserId && u.isActive
                                  join uod in db.UrunOnayDurum on u.Id equals uod.UrunId
                                  where uod.isActive
                                  select new UrunListWithStatusDTO()
                                  {
                                      TakipNumarasi = uod.TakipNumarasi,
                                      Adi = u.Adi,
                                      OnayDurumu = (Commons.OnayDurum)uod.OnayDurumId
                                  }).OrderBy(x => x.OnayDurumu).ToList();
                }

                logDTO.OperationResult = IslemSonuc.Success;
                logDTO.OperationNote = $"Kullanıcı tarafından başarılı eklenen ürün listesini çekme işlemi.";

                _logger.DoLog(logDTO);

                return resultList;
            }
            catch (Exception ex)
            {
                //Logging
                logDTO.OperationResult = IslemSonuc.Error;
                logDTO.OperationNote = $"Kullanıcı tarafından başarısız eklenen ürün listesini çekme işlemi. Hata mesajı: " + ex.Message;

                _logger.DoLog(logDTO);

                //Caught for logging so throw agan
                throw;
            }
        }

        /// <summary>
        /// Used for user registration when checking if username or email is unavailable
        /// </summary>
        /// <param name="kayitValidation">KullaniciKayitValidation object to append errors</param>
        /// <param name="userName">Username to be checked</param>
        /// <param name="email">Email to be checked</param> 
        private void CheckExistingUserNameEmail(KullaniciKayitValidation kayitValidation, string userName, string email)
        {
            ProDAL<Kullanici> kDal = new ProDAL<Kullanici>();
            if (!(kDal.GetBy(k => k.KullaniciAdi == userName).Count == 0))
            {
                kayitValidation.ValidationMessages.Add("Kullanıcı Adı kullanılıyor.");
                kayitValidation.IsValid = false;
            }

            if (!(kDal.GetBy(k => k.Email == email).Count == 0))
            {
                kayitValidation.ValidationMessages.Add("Email kullanılıyor.");
                kayitValidation.IsValid = false;
            }
        }
    }
}
