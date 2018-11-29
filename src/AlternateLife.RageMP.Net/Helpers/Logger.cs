using System;
using System.Diagnostics;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Interfaces;
using NLog.Config;
using LogManager = NLog.LogManager;

namespace AlternateLife.RageMP.Net.Helpers
{
    internal class Logger : ILogger
    {
        private readonly Plugin _plugin;

        public int FramesToSkip { get; set; } = 3;

        public Logger(Plugin plugin)
        {
            _plugin = plugin;

            LogManager.Configuration = new XmlLoggingConfiguration(_plugin.GetBasePath("NLog.config"));
        }

        public void Log(LogLevel logLevel, string message, Exception exception = null)
        {
            var logger = LogManager.GetLogger(GetCallerType());

            NLog.LogLevel level;
            switch (logLevel)
            {
                case LogLevel.Trace:
                    level = NLog.LogLevel.Trace;
                    break;

                case LogLevel.Debug:
                    level = NLog.LogLevel.Debug;
                    break;

                case LogLevel.Warn:
                    level = NLog.LogLevel.Warn;
                    break;

                case LogLevel.Error:
                    level = NLog.LogLevel.Error;
                    break;

                case LogLevel.Fatal:
                    level = NLog.LogLevel.Fatal;
                    break;

                default:
                    level = NLog.LogLevel.Info;
                    break;
            }

            if (exception != null)
            {
                logger.Log(level, exception, message);
            }
            else
            {
                logger.Log(level, message);
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

        public void Fatal(string message, Exception exception = null)
        {
            Log(LogLevel.Fatal, message, exception);
        }

        private string GetCallerType()
        {
            string className;
            var framesToSkip = FramesToSkip;
            var lastClass = string.Empty;

            do
            {
                var frame = new StackFrame(framesToSkip, false);
                var method = frame.GetMethod();

                if (method == null)
                {
                    className = lastClass;

                    break;
                }

                var declaringType = method.DeclaringType;
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
