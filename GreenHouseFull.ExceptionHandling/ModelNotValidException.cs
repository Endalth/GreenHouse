using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.ExceptionHandling
{
    public class ModelNotValidException : ExceptionBase
    {
        public List<string> ValidationMessages { get; set; }

        public ModelNotValidException(List<string> messages)
        {
            ValidationMessages = messages;
        }

        public ModelNotValidException(List<string> messages, string message) : base(message)
        {
            ValidationMessages = messages;
        }

        public ModelNotValidException(List<string> messages, string message, Exception innerEx) : base(message, innerEx)
        {
            ValidationMessages = messages;
        }
    }
}
