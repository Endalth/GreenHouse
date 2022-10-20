using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.ExceptionHandling
{
    public class ExceptionBase : Exception
    {
        public ExceptionBase()
        {

        }

        public ExceptionBase(string message) : base(message)
        {

        }

        public ExceptionBase(string msg, Exception innerException) : base(msg, innerException)
        {

        }
    }
}
