using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Redis
{
    public class RedisManager
    {
        private static object _lock = new object();

        private static ConnectionMultiplexer instance;

        /// <summary>
        /// 在redis中获得一个与数据库的交互连接
        /// </summary>
        protected static IDatabase DbContext
        {
            get
            {
                return Instance.GetDatabase();
            }
        }

        /// <summary>
        /// 通过单例的方式创建多路复用器
        /// </summary>
        protected static ConnectionMultiplexer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                        if (instance != null)
                            return instance;
                        else
                            instance = GetManager();
                        return instance;
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// 返回连接多路复用器
        /// </summary>
        /// <returns></returns>
        private static ConnectionMultiplexer GetManager()
        {
            //redis 连接字符串
            string conncectionStr = Config.ConfigManagemt.Config.Redis.Host;
            if (string.IsNullOrEmpty(conncectionStr))
            {
                throw new ArgumentNullException("请配置redis连接字符串");
            }
            //创建一个新的连接多路复用器实例
            return ConnectionMultiplexer.Connect(conncectionStr);
        }
    }
}
