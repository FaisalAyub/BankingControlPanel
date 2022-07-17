using System;
using NLog;
using System.Reflection;

namespace MCN.Infrastructure.Logging
{
    public interface ILoggingService
    {
        void Info(string message);
        void Warn(string message);
        void Debug(string message);
        void Error(string message);
        void Error(string message, Exception x);
        void Error(Exception x);
        void Fatal(string message);
        void Fatal(Exception x);
    }
    public class LockLoggingService
    {
        public static void LockErrorLog(Exception x)
        {
            new LoggingService().Error(x);
        }
        public static void LockErrorLog(string message, Exception x)
        {
            new LoggingService().Error(message, x);
        }
        public static void LockErrorLog(Exception x, ParameterInfo[] parameters, params object[] args)
        {
            string message = "";
            try
            {
                for (var i = 0; i < args.Length; i++)
                {
                    try
                    {
                        message += "" + parameters[i].Name + ":" + args[i] + ",";
                    }
                    catch (Exception) { message += "" + parameters[i].Name + ":null,"; }
                }
            }
            catch (Exception) { }
            new LoggingService().Error(message, x);
        }
    }
    public class LoggingService : NLog.Logger, ILoggingService
    {
        private readonly Logger _logger;

        public LoggingService()
        {
            _logger = (Logger)LogManager.GetCurrentClassLogger(typeof(Logger));
        }
        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Error(Exception x)
        {
            Error(new LogUtility().BuildExceptionMessage(x));
        }

        public void Error(string message, Exception x)
        {
            Error(new LogUtility().BuildExceptionMessage(x) + System.Environment.NewLine + "Custom Message: " + message);
            //_logger.ErrorException(message, x);
        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public void Fatal(Exception x)
        {
            Fatal(new LogUtility().BuildExceptionMessage(x));
        }
    }
}
