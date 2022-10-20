using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DTO
{
    public class UrunDuzeltmeTalepEkleDTO
    {
        public int UrunId { get; set; }
        public string Aciklama { get; set; }
        public byte[] Resim { get; set; }
        public string OnayAciklama { get; set; }
        public int OnayDurumId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public bool isActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
