using GreenHouseFull.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DTO
{
    public class UrunIcerikDTO
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public Commons.RiskSeviye RiskSeviyeId { get; set; }

        public bool KaraListede { get; set; }
        public string Aciklama { get; set; }
        public int UsedInCount { get; set; }
    }
}
