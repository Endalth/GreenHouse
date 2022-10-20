using GreenHouseFull.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DTO
{
    public class ProfilDTO
    {
        public string KullaniciAdi { get; set; }
        public Commons.Rols RolId { get; set; }
        public DateTime KayitTarihi { get; set; }
        public int UrunSayisi { get; set; }

    }
}
