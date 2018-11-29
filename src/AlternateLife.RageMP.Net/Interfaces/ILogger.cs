using System;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface ILogger
    {
        /// <summary>
        /// Defines how many methods the class detector should skip on a log message.
        ///
        /// This property is very useful, if you create your own wrapper that utilizes this method.
        /// </summary>
        int FramesToSkip { get; set; }

        /// <summary>
        /// Log a trace message.
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="exception">Exception to log</param>
        void Trace(string message, Exception exception = null);

        /// <summary>
        /// Log a debug message.
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="exception">Exception to log</param>
        void Debug(string message, Exception exception = null);

        /// <summary>
        /// Log an info message.
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="exception">Exception to log</param>
        void Info(string message, Exception exception = null);

        /// <summary>
        /// Log a warning message.
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="exception">Exception to log</param>
        void Warn(string message, Exception exception = null);

        /// <summary>
        /// Log an error message.
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="exception">Exception to log</param>
        void Error(string message, Exception exception = null);

        /// <summary>
        /// Log an fatal message.
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="exception">Exception to log</param>
        void Fatal(string message, Exception exception = null);
    }
}
