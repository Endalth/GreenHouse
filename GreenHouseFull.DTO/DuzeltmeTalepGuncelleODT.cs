using GreenHouseFull.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DTO
{
    public class DuzeltmeTalepGuncelleODT
    {
        public int Id { get; set; }
        public Commons.OnayDurum OnayDurumId { get; set; }
        public string OnayAciklama { get; set; }
    }
}
