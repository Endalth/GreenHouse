using GreenHouseFull.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenHouseFull.Core.Context
{
    public class Kategori :MyEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Adi { get; set; }
        public Nullable<int> UstKategoriId { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public int ModifiedBy { get; set; }


        public Kategori Kategori_Ust { get; set; }
        public Kullanici Kullanici_CB { get; set; }
        public Kullanici Kullanici_MB { get; set; }


        public virtual ICollection<Kategori> Kategori_Usts { get; set; }

        public virtual ICollection<Urun> Uruns { get; set; }
    }
}