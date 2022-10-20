using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DTO
{
    public class KullaniciSimpleListDTO
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }

        public override string ToString()
        {
            return KullaniciAdi;
        }
    }
}
