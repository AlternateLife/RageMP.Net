using System;
using System.Diagnostics;
using System.Reflection;
using NLog;
using NLog.Config;
using ILogger = AlternateLife.RageMP.Net.Interfaces.ILogger;

namespace AlternateLife.RageMP.Net.Helpers
{
    internal class Logger : Interfaces.ILogger
    {
        private readonly Plugin _plugin;

        public Logger(Plugin plugin)
        {
            _plugin = plugin;

            LogManager.Configuration = new XmlLoggingConfiguration(_plugin.GetBasePath("NLog.config"));
        }

        private void Log(LogLevel logLevel, string message, Exception exception = null)
        {
            var logger = LogManager.GetLogger(GetCallerType());

            if (exception != null)
            {
                logger.Log(logLevel, exception, message);
            }
            else
            {
                logger.Log(logLevel, message);
            }
        }

        public void Trace(string message, Exception exception = null)
        {
            Log(LogLevel.Trace, message, exception);
        }

        public void Debug(string message, Exception exception = null)
        {
            Log(LogLevel.Debug, message, exception);
        }

        public void Info(string message, Exception exception = null)
        {
            Log(LogLevel.Info, message, exception);
        }

        public void Warn(string message, Exception exception = null)
        {
            Log(LogLevel.Warn, message, exception);
        }

        public void Error(string message, Exception exception = null)
        {
            Log(LogLevel.Error, message, exception);
        }

        private string GetCallerType()
        {
            string className;
            var framesToSkip = 3;
            var lastClass = "";

            do
            {
                StackFrame frame = new StackFrame(framesToSkip, false);

                MethodBase method = frame.GetMethod();

                if (method == null)
                {
                    className = lastClass;
                    break;
                }

                Type declaringType = method.DeclaringType;
                if (declaringType == null)
                {
                    className = method.Name;
                    break;
                }


                framesToSkip++;
                className = declaringType.FullName;
                lastClass = className;
            } while (className.StartsWith("System.", StringComparison.Ordinal));

            return className;
        }
    }
}
