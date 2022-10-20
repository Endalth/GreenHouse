using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DTO
{
    public enum IslemSonuc
    {
        Success,
        Error
    }

    public enum IslemTur
    {
        Get_Data,
        Add,
        Erase,
        Update
    }

    public class LogDTO
    {
        public int UserIdToPerformTheOperation { get; set; }
        public IslemTur OperationType { get; set; }
        public IslemSonuc OperationResult { get; set; }
        public string MethodName { get; set; }
        public string OperationNote { get; set; }
        public DateTime LogDate { get; set; } = DateTime.Now;
    }
}
