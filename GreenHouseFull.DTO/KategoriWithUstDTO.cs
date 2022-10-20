using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DTO
{
    public class KategoriWithUstDTO
    {
        public int KategoriId { get; set; }
        public string Name { get; set; }
        public string UstName { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
