using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    public class ConfigModel
    {
        //[XmlElement("Logger")]
        //[XmlChoiceIdentifier("Logger")]
        [XmlElement(ElementName = "Logger")]
        //[XmlElement(Order =0)]
        public LoggerModel Logger { get; set; }

        [XmlElement(ElementName = "PubSub")]
        //[XmlElement(Order =1)]
        public PubSubModel PubSub { get; set; }

        [XmlElement(ElementName = "Redis")]
        //[XmlElement(Order =2)]
        public RedisModel Redis { get; set; }

        /// <summary>
        /// 在无参构造函数中实例化需要加载的配置对象
        /// </summary>
        public ConfigModel()
        {
            Logger = new LoggerModel();
            PubSub = new PubSubModel();
            Redis = new RedisModel();
        }
    }
}
