using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.Log
{
    public interface ILogger<T>
    {
        void DoLog(T data);
    }
}
