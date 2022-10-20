using GreenHouseFull.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.Core.Interfaces
{
    public interface ISelectableRepo<T> : IRepo<T> where T : MyEntityBase
    {
        List<T> GetAll();
        T GetByID(object ID);
        List<T> GetBy(Func<T, bool> whereCondition);
        T GetByFirst(Func<T, bool> whereCondition);
    }
}
