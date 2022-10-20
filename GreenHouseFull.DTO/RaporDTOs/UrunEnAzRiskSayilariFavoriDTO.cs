using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DTO.RaporDTOs
{
    public class UrunEnAzRiskSayilariFavoriDTO
    {
        public string UrunAdi { get; set; }
        public int TemizRiskSayi { get; set; }
        public int AzRiskSayi { get; set; }
        public bool Favoride { get; set; }
    }
}
