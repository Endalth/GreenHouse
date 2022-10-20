using GreenHouseFull.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenHouseFull.Core.Context
{
    public class KullaniciUrunIcerikKaraListe : MyEntityBase
    {
        [Key, Column(Order = 0)]
        public int CreatedBy { get; set; }
        [Key, Column(Order =1)]
        public int UrunIcerikId { get; set; }
        [Required]
        public int ModifiedBy { get; set; }


        public virtual UrunIcerik UrunIcerik { get; set; }
        public Kullanici Kullanici_CB { get; set; }
        public Kullanici Kullanici_MB { get; set; }
    }
}