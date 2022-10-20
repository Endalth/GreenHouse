using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DTO
{
    public class UrunEkleDTO
    {
        public Guid Barkod { get; set; }
        public string Adi { get; set; }
        public byte[] Icerik { get; set; }
        public byte[] OnYuz { get; set; }
        public byte[] ArkaYuz { get; set; }
        public bool KullaniciGoster { get; set; }
        public List<int> UrunIcerikIds { get; set; }
        public int KategoriId { get; set; }
        public int UreticiId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public bool isActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
