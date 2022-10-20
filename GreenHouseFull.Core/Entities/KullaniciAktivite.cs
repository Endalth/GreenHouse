using GreenHouseFull.Core.Entities;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenHouseFull.Core.Context
{
    public class KullaniciAktivite : MyEntityBase
    {
        [Key, Column(Order = 0)]
        public int CreatedBy { get; set; }
        [Key, Column(Order = 1)]
        public int AktiviteId { get; set; }
        [Required]
        public int ModifiedBy { get; set; }


        public virtual Aktivite Aktivite { get; set; }
        public Kullanici Kullanici_CB { get; set; }
        public Kullanici Kullanici_MB { get; set; }
    }
}