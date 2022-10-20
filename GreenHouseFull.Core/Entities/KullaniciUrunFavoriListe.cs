using GreenHouseFull.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenHouseFull.Core.Context
{
    public class KullaniciUrunFavoriListe : MyEntityBase
    {
        [Key, Column(Order =0)]
        public int ListeId { get; set; }
        [Key, Column(Order =1)]
        public int UrunId { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public int ModifiedBy { get; set; }


        public virtual KullaniciFavoriListe KullaniciFavoriListe { get; set; }
        public virtual Urun Urun { get; set; }
        public Kullanici Kullanici_CB { get; set; }
        public Kullanici Kullanici_MB { get; set; }
    }
}