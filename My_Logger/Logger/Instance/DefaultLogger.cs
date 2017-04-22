using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Logger.Logger.Instance
{
    public class DefaultLogger : ILogger
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
            Console.WriteLine(msg);
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
