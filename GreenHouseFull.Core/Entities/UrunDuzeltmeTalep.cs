using GreenHouseFull.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenHouseFull.Core.Context
{
    public class UrunDuzeltmeTalep : MyEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(1000)]
        public string Aciklama { get; set; }
        public byte[] Resim { get; set; } //not set to required at first to make data insert easier
        [Required, StringLength(1000)]
        public string OnayAciklama { get; set; }
        [Required]
        public int OnayDurumId { get; set; }
        [Required]
        public int UrunId { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public int ModifiedBy { get; set; }


        public virtual Urun Urun { get; set; }
        public virtual OnayDurum OnayDurum { get; set; }
        public Kullanici Kullanici_CB { get; set; }
        public Kullanici Kullanici_MB { get; set; }
    }
}