using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Logger.Logger.Instance
{
    public class Log4NetLogger : ILogger
    {
        public void Logger_Debug(string msg)
        {
            throw new NotImplementedException();
        }

        public void Logger_Error(Exception ex)
        {
            throw new NotImplementedException();
        }

        public void Logger_Exception(string msg, Action action)
        {
            throw new NotImplementedException();
        }

        public void Logger_Fatal(string msg)
        {
            throw new NotImplementedException();
        }

        public void Logger_Info(string msg)
        {
            Console.WriteLine("我是log4net的测试日志组建——info");
        }

        public void Logger_Timer(string msg, Action action)
        {
            throw new NotImplementedException();
        }

        public void Logger_Warn(string msg)
        {
            throw new NotImplementedException();
        }
    }
}
