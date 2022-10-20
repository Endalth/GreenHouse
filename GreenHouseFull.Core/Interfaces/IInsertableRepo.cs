using GreenHouseFull.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.Core.Interfaces
{
    public interface IInsertableRepo<T> : IRepo<T> where T : MyEntityBase
    {
        T Add(T item);
        List<T> AddRange(List<T> items);
    }
}
