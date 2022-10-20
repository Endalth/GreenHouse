using GreenHouseFull.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.Validation
{
    public class UrunEkleValidation : ValidationBase<UrunEkleDTO>
    {
        public UrunEkleValidation(UrunEkleDTO model) : base(model)
        {
        }

        protected override void OnValidate()
        {
            CheckUrunAdi();
            CheckImages();
            CheckUrunIcerik();
            CheckBarkod();
            CheckKategori();
            CheckUretici();
        }

        private void CheckUretici()
        {
            if (Model.UreticiId == -1)
            {
                IsValid = false;
                ValidationMessages.Add("Üretici seçiniz.");
            }
        }

        private void CheckKategori()
        {
            if(Model.KategoriId == -1)
            {
                IsValid = false;
                ValidationMessages.Add("Kategori seçiniz.");
            }
        }

        private void CheckBarkod()
        {
            if(Model.Barkod == Guid.Empty)
            {
                IsValid = false;
                ValidationMessages.Add("Barkod tam girilmelidir.");
            }
        }

        private void CheckUrunIcerik()
        {
            if(Model.UrunIcerikIds.Count == 0)
            {
                IsValid = false;
                ValidationMessages.Add("Ürün içeriği boş geçilemez.");
            }
        }

        private void CheckImages()
        {
            if(Model.Icerik == null)
            {
                IsValid = false;
                ValidationMessages.Add("İçerik resmi boş geçilemez.");
            }

            if(Model.OnYuz == null)
            {
                IsValid = false;
                ValidationMessages.Add("Ön yüz resmi boş geçilemez");
            }

            if (Model.ArkaYuz== null)
            {
                IsValid = false;
                ValidationMessages.Add("Arka yüz resmi boş geçilemez");
            }
        }

        private void CheckUrunAdi()
        {
            if (Model.Adi.Length == 0 || Model.Adi.Length > 100)
            {
                IsValid = false;
                ValidationMessages.Add("Ürün Adı uzunluğu 0dan büyük ve 100den küçük olmalı");
            }
        }
    }
}
