using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.Log
{
    public class NLogLogger<T> : ILogger<T> where T : class
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private string _logFileName;

        public NLogLogger(string logFileName)
        {
            _logFileName = logFileName;
        }

        public void DoLog(T data)
        {
            _logger.Info("LogInfo: {logInfo}, LogFileName = {LogFileName}", data, _logFileName);
        }
    }
}
