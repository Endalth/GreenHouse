using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DTO
{
    public class UrunDTO
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public byte[] OnYuz { get; set; }
        public byte[] ArkaYuz { get; set; }
        public string KullaniciAdi { get; set; }
        public string KategoriAdi { get; set; }
        public string UreticiAdi { get; set; }
        public List<UrunIcerikUrunListeDTO> IcerikList { get; set; }
        public bool Favoride { get; set; }
    }
}
