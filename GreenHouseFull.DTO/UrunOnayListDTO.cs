using GreenHouseFull.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DTO
{
    public class UrunOnayListDTO
    {
        public Guid TakipNumarasi { get; set; }
        public string UrunAdi { get; set; }
        public Commons.OnayDurum OnayDurumId { get; set; }
        public string Aciklama { get; set; }
        public string UrunuEkleyen { get; set; }
    }
}
