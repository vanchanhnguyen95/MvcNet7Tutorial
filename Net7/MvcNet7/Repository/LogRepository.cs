using log4net;
using log4net.Config;
using log4net.Core;
using MvcNet7.Interfaces;
using System.Reflection;
using LogLevel = MvcNet7.Interfaces.LogLevel;

namespace MvcNet7.Repository
{
    public class LogRepository: ILogRepository
    {
        private ILog myLog4net;

        public LogRepository()
        {
            log4net.Config.XmlConfigurator.Configure();
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            myLog4net = LogManager.GetLogger(typeof(LoggerManager));
        }

        public bool WriteLog(string message, Interfaces.LogLevel level)
        {
            if (myLog4net != null)
            {
                switch (level)
                {
                    case LogLevel.Error:
                        if (myLog4net.IsErrorEnabled)
                            myLog4net.Error(message);
                        break;

                    case LogLevel.Debug:
                        if (myLog4net.IsDebugEnabled)
                            myLog4net.Debug(message);
                        break;

                    case LogLevel.Fatal:
                        if (myLog4net.IsFatalEnabled)
                            myLog4net.Fatal(message);
                        break;

                    case LogLevel.Info:
                        if (myLog4net.IsInfoEnabled)
                            myLog4net.Info(message);
                        break;

                    case LogLevel.Warn:
                        if (myLog4net.IsWarnEnabled)
                            myLog4net.Warn(message);
                        break;
                }
                return true;

            }

            return false;
        }
    }
}
