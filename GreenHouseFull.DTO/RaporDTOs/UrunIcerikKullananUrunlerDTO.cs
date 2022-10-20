using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DTO
{
    public class UrunIcerikKullananUrunlerDTO
    {
        public string IcerikAdi { get; set; }
        public List<string> UrunAdi { get; set; }
    }
}
