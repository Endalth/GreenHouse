using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.ExceptionHandling
{
    public class ExistsException : ExceptionBase
    {

        public ExistsException(string message) : base(message)
        {
        }

        public ExistsException(string msg, Exception innerException) : base(msg, innerException)
        {
        }
    }
}
