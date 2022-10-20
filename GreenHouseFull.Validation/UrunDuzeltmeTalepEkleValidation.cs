using GreenHouseFull.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.Validation
{
    public class UrunDuzeltmeTalepEkleValidation : ValidationBase<UrunDuzeltmeTalepEkleDTO>
    {
        public UrunDuzeltmeTalepEkleValidation(UrunDuzeltmeTalepEkleDTO model) : base(model)
        {
        }

        protected override void OnValidate()
        {
            CheckImage();
            CheckAciklama();
        }

        void CheckImage()
        {
            if(Model.Resim == null)
            {
                IsValid = false;
                ValidationMessages.Add("Kanıt resmi boş olamaz.");
            }
        }

        void CheckAciklama()
        {
            if(Model.Aciklama.Length == 0 || Model.Aciklama.Length > 1000)
            {
                IsValid = false;
                ValidationMessages.Add("Aciklama uzunluğu 0'dan büyük 1000 karakterden az olmalıdır.");
            }
        }
    }
}
