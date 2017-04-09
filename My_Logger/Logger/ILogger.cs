using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Logger.Logger
{
    public interface ILogger
    {
        /// <summary>
        /// 记录代码运行时间，
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="action">所测试的代码块</param>
        void Logger_Timer(string msg, Action action);

        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="action">try catch</param>
        void Logger_Exception(string msg, Action action);

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="msg"></param>
        void Logger_Info(string msg);

        /// <summary>
        /// 记录异常信息
        /// </summary>
        /// <param name="ex"></param>
        void Logger_Error(Exception ex);

        /// <summary>
        /// 调试期间日志
        /// </summary>
        /// <param name="msg"></param>
        void Logger_Debug(string msg);

        /// <summary>
        /// 引起程序终止的日志
        /// </summary>
        /// <param name="msg"></param>
        void Logger_Fatal(string msg);

        /// <summary>
        /// 报警日志
        /// </summary>
        /// <param name="msg"></param>
        void Logger_Warn(string msg);
    }
}
