using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.ExceptionHandling
{
    public class SameValueException : ExceptionBase
    {
        public SameValueException(string message) : base(message)
        {
        }

        public SameValueException(string msg, Exception innerException) : base(msg, innerException)
        {
        }
    }
}
