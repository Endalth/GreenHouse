using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DTO
{
    public class UserFavoriteListsWithProductsDTO
    {
        public string ListeAdi { get; set; }
        public List<UrunSimpleListDTO> UrunsInList { get; set; }
    }
}
