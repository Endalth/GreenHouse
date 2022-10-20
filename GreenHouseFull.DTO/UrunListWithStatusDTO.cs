using GreenHouseFull.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DTO
{
    public class UrunListWithStatusDTO
    {
        public Guid TakipNumarasi { get; set; }
        public string Adi { get; set; }
        public Commons.OnayDurum OnayDurumu{ get; set; }

        public override string ToString()
        {
            return Adi + " - " + OnayDurumu.ToString().Replace("_", " ");
        }
    }
}
