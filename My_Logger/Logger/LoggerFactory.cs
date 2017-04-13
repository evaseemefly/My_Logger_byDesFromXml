using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Logger.Logger
{
    public class LoggerFactory : ILogger
    {
        /// <summary>
        /// 日志提供者，只在本例中实例化
        /// </summary>
        private ILogger iLogger;

        /// <summary>
        /// 
        /// 注意此处简写了，若ConfigManagemt.Config.Logger.Level为空则为Level赋值为DEBUG
        /// </summary>
        private static Enum.Level level = (Enum.Level)System.Enum.Parse(typeof(Enum.Level), (Config.ConfigManagemt.Config.Logger.Level ?? "DEBUG").ToUpper());

        /// <summary>
        /// 线程锁
        /// </summary>
        private static object lockObj = new object();

        /// <summary>
        /// 日志工厂实例
        /// </summary>
        private static LoggerFactory instance;

        /// <summary>
        /// 单例模式获取日志工厂对象
        /// </summary>
        public static LoggerFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new LoggerFactory();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// 构造函数为私有的构造函数
        /// 只在Instance属性中通过单例模式调用，外部不能直接调用此构造函数
        /// </summary>
        private LoggerFactory()
        {
            //日志种类
            string type = "file";
            if (Config.ConfigManagemt.Config != null)
                type=Config.ConfigManagemt.Config.Logger.Type.ToLower();

            switch (type)
            {
                case "file":
                    iLogger = new Instance.DefaultLogger();
                    break;
                case "log4net":
                    iLogger = new Instance.Log4NetLogger();
                    break;
                default:
                    iLogger = new Instance.DefaultLogger();
                    break;

            }
        }
        /// <summary>
        /// 记录代码段执行时间
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="action">要执行的代码段</param>
        public void Logger_Timer(string message, Action action)
        {
            iLogger.Logger_Timer(message, action);
        }
        /// <summary>
        /// 记录代码段执行时出现的异常信息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="action">要执行的代码段</param>
        public void Logger_Exception(string message, Action action)
        {
            iLogger.Logger_Exception(message, action);
        }
        /// <summary>
        /// Debug级别的日志
        /// </summary>
        /// <param name="message"></param>
        public void Logger_Debug(string message)
        {
            if (level <= Enum.Level.DEBUG)
                iLogger.Logger_Debug(message);
        }
        /// <summary>
        /// Info级别的日志
        /// </summary>
        /// <param name="message"></param>
        public void Logger_Info(string message)
        {
            if (level <= Enum.Level.INFO)
                iLogger.Logger_Info(message);
        }
        /// <summary>
        /// Warn级别的日志
        /// </summary>
        /// <param name="message"></param>
        public void Logger_Warn(string message)
        {
            if (level <= Enum.Level.WARN)
                iLogger.Logger_Warn(message);
        }
        /// <summary>
        /// Error级别的日志
        /// </summary>
        /// <param name="ex"></param>
        public void Logger_Error(Exception ex)
        {
            if (level <= Enum.Level.ERROR)
                iLogger.Logger_Error(ex);
        }
        /// <summary>
        /// Fatal级别的日志
        /// </summary>
        /// <param name="message"></param>
        public void Logger_Fatal(string message)
        {
            if (level <= Enum.Level.FATAL)
                iLogger.Logger_Fatal(message);
        }
    }
}
