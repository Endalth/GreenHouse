using GreenHouseFull.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenHouseFull.Core.Context
{
    public class UrunOnayDurum : MyEntityBase
    {
        [Key]
        public Guid TakipNumarasi { get; set; }
        [Required]
        public int UrunId { get; set; }
        [Required]
        public int OnayDurumId { get; set; }
        [Required, StringLength(300)]
        public string Aciklama { get; set; }
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