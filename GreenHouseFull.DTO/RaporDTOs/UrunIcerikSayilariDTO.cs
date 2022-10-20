using GreenHouseFull.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DTO.RaporDTOs
{
    public class UrunIcerikSayilariDTO
    {
        public string UrunAdi { get; set; }
        public List<RiskSeviyeAdetDTO> RiskSeviyeSayilari { get; set; }
    }
}
