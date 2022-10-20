using GreenHouseFull.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenHouseFull.Core.Context
{
    public class UrunUrunIcerik : MyEntityBase
    {
        [Key, Column(Order =0)]
        public int UrunId { get; set; }
        [Key, Column(Order =1)]
        public int UrunIcerikId { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public int ModifiedBy { get; set; }


        public Urun Urun { get; set; }
        public UrunIcerik UrunIcerik { get; set; }
        public Kullanici Kullanici_CB { get; set; }
        public Kullanici Kullanici_MB { get; set; }
    }
}