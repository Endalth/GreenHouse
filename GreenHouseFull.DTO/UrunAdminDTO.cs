using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DTO
{
    public class UrunAdminDTO
    {
        public Guid Barkod { get; set; }
        public string Adi { get; set; }
        public byte[] Icerik { get; set; }
        public byte[] OnYuz { get; set; }
        public byte[] ArkaYuz { get; set; }
        public bool KullaniciGoster { get; set; }
        public List<UrunIcerikSimpleListDTO> UrunIceriks { get; set; }
        public string KategoriAdi { get; set; }
        public string UreticiAdi { get; set; }
        public string EkleyenKullanici { get; set; }
    }
}
