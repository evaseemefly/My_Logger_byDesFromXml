using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    public class Config_Model
    {
        //[XmlElement("Logger")]
        //[XmlChoiceIdentifier("Logger")]
        [XmlElement(ElementName = "Logger")]
        //[XmlElement(Order =0)]
        public Logger_Model Logger { get; set; }

        [XmlElement(ElementName = "PubSub")]
        //[XmlElement(Order =1)]
        public PubSub_Model PubSub { get; set; }

        [XmlElement(ElementName = "Redis")]
        //[XmlElement(Order =2)]
        public Redis_Model Redis { get; set; }

        /// <summary>
        /// 在无参构造函数中实例化需要加载的配置对象
        /// </summary>
        public Config_Model()
        {
            Logger = new Logger_Model();
            PubSub = new PubSub_Model();
            Redis = new Redis_Model();
        }
    }
}
