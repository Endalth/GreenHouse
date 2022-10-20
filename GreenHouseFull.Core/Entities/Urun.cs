using GreenHouseFull.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenHouseFull.Core.Context
{
    public class Urun : MyEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid Barkod { get; set; }
        [Required, StringLength(100)]
        public string Adi { get; set; }
        public byte[] Icerik { get; set; } //not set to required at first to make data insert easier
        public byte[] OnYuz { get; set; } //not set to required at first to make data insert easier
        public byte[] ArkaYuz { get; set; } //not set to required at first to make data insert easier
        [Required]
        public bool KullaniciGoster { get; set; }
        [Required]
        public int KategoriId { get; set; }
        [Required]
        public int UreticiId { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public int ModifiedBy { get; set; }


        public Kategori Kategori { get; set; }
        public Uretici Uretici { get; set; }
        public Kullanici Kullanici_CB { get; set; }
        public Kullanici Kullanici_MB { get; set; }

        public ICollection<KullaniciGecmisArama> KullaniciGecmisAramas { get; set; }

        public ICollection<KullaniciUrunFavoriListe> KullaniciUrunFavoriListes { get; set; }

        public ICollection<UrunDuzeltmeTalep> UrunDuzeltmeTaleps { get; set; }

        public ICollection<UrunOnayDurum> UrunUrunDurums { get; set; }

        public ICollection<UrunUrunIcerik> UrunUrunIceriks { get; set; }
    }
}