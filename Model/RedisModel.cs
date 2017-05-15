using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RedisModel
    {
        #region Redis
        /// <summary>
        /// redis缓存的连接串
        /// var conn = ConnectionMultiplexer.Connect("contoso5.redis.cache.windows.net,password=...");
        /// </summary>
        [DisplayName("StackExchange.redis缓存的连接串")]
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Host { get; set; }
        [DisplayName("StackExchange.redis代理模式（可选0:无，1：TW")]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public int Proxy { get; set; }

        #endregion
    }
}
