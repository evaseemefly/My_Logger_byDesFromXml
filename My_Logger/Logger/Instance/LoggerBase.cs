using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace My_Logger.Logger.Instance
{
    internal abstract class LoggerBase : ILogger
    {
        private string _defaultLoggerName = DateTime.Now.ToString("yyyyMMddhh") + ".log";
        private string dir_ext = "LoggerDir";

        /// <summary>
        /// 日志文件地址
        /// </summary>
        protected string FileUrl
        {
            
            get
            {
                try
                {
                    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dir_ext);
                }
                catch (Exception)
                {
                    try
                    {
                        return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), dir_ext);
                    }
                    catch (Exception)
                    {

                        return Path.Combine(System.Web.HttpContext.Current.Request.PhysicalApplicationPath, dir_ext);
                    }
                    throw;
                }
            }
        }

        /// <summary>
        /// 日志持久化的方法
        /// </summary>
        /// <param name="msg"></param>
        protected abstract void InputLogger(string msg);

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
            throw new NotImplementedException();
        }

        public void Logger_Timer(string msg, Action action)
        {
            StringBuilder str = new StringBuilder();
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            str.Append(msg);
            action();
            str.Append("Logger_Timer:代码段运行时间(" + sw.ElapsedMilliseconds + "毫秒)");
            InputLogger(str.ToString());
            sw.Stop();
        }

        public void Logger_Warn(string msg)
        {
            throw new NotImplementedException();
        }
    }
}
