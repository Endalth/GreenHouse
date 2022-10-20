using GreenHouseFull.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenHouseFull.Core.Context
{
    public class RolYetki : MyEntityBase
    {
        [Key, Column(Order = 0)]
        public int RolId { get; set; }
        [Key, Column(Order =1)]
        public int YetkiId { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public int ModifiedBy { get; set; }


        public Rol Rol { get; set; }
        public Yetki Yetki { get; set; }
        public Kullanici Kullanici_CB { get; set; }
        public Kullanici Kullanici_MB { get; set; }
    }
}