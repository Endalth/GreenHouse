using GreenHouseFull.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DTO
{
    public class DuzeltmeTalepListeDTO
    {
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public Commons.OnayDurum OnayDurumId { get; set; }

        public override string ToString()
        {
            return UrunAdi + " - " + OnayDurumId.ToString().Replace("_", " ");
        }
    }
}
