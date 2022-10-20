using GreenHouseFull.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenHouseFull.Core.Context
{
    public class RiskSeviye : MyEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Adi { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public int ModifiedBy { get; set; }


        public Kullanici Kullanici_CB { get; set; }
        public Kullanici Kullanici_MB { get; set; }

        public ICollection<UrunIcerik> UrunIceriks { get; set; }
    }
}