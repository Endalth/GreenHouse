using GreenHouseFull.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GreenHouseFull.Validation
{
    public class KullaniciKayitValidation : ValidationBase<KullaniciKayitDTO>
    {
        public KullaniciKayitValidation(KullaniciKayitDTO model) : base(model)
        {

        }

        protected override void OnValidate()
        {
            KullaniciAdiValidate();
            SifreValidate();
            EmailValidate();
        }

        private void KullaniciAdiValidate()
        {
            //Karakter limit
            if (Model.KullaniciAdi.Length == 0 || Model.KullaniciAdi.Length > 100)
            {
                IsValid = false;
                ValidationMessages.Add("Kullanıcı Adı uzunluğu 0dan büyük ve 100den küçük olmalı");
            }

            if (Model.KullaniciAdi.Contains(" "))
            {
                IsValid = false;
                ValidationMessages.Add("Kullanıcı Adı boşluk içeremez.");
            }
        }

        private void SifreValidate()
        {
            //Karakter limit
            if (Model.Sifre.Length == 0 || Model.Sifre.Length > 100)
            {
                IsValid = false;
                ValidationMessages.Add("Şifre uzunluğu 0dan büyük ve 100den küçük olmalı");
            }

            if (Model.Sifre.Contains(" "))
            {
                IsValid = false;
                ValidationMessages.Add("Şifre boşluk içeremez.");
            }
        }

        private void EmailValidate()
        {
            // Email format
            Match emailFormatCheck = Regex.Match(Model.Email, @"[\w-\.]+@([\w-]+\.)+[\w-]{2,4}");
            if (!emailFormatCheck.Success)
            {
                IsValid = false;
                ValidationMessages.Add("Email formatı yanlış sadece harf, rakam yada \"-\", \"_\", \".\" karakterlerini kullanabilirsiniz. Örnek: ornek@email.com");
            }
        }
    }
}
