using GreenHouseFull.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DTO
{
    public class UrunIcerikUrunListeDTO
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public Commons.RiskSeviye RiskSeviyeId { get; set; }

        public bool KaraListede { get; set; }

        public override string ToString()
        {
            return Adi;
        }
    }
}
