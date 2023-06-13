using Authentication.BusinessLogic.Services.Interfaces;
using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.BusinessLogic.Services.Implementations
{
    public class LoggerService : ILoggerService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public LoggerService() { }  

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarning(string message)
        {
            logger.Warn(message);
        }
    }
}
