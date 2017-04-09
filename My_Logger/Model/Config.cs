using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace My_Logger.Model
{
    //XmlRoot表明这个类对应的是XML文件中的根节点
    [XmlRoot(ElementName = "Config")]
    public class Config
    {
        //XmlElement表明这个字段对应的是XML文件中当前父节点下面的一个子节点
        //ElementName就是XML里面显示的当前节点名称
        //类中的字段名称与对应的XML节点的名称可以不同(比如在这里类Config中的属性ClientDescription对应XML文件中根节点Config下面的子节点Description)
        [XmlElement(ElementName = "Description")]
        public string ClientDescription { get; set; }

        //XmlAttribute表明这个字段是XML文件中当前节点的一个属性
        [XmlAttribute(AttributeName = "IsAuto")]
        public string IsAuto { get; set; }

        [XmlElement(ElementName = "CustomerInfos")]
        public CustomerInfos CustomerInfos
        {
            get;
            set;
        }

        [XmlElement(ElementName = "ScanConfigs")]
        public ScanConfigs ScanConfigs
        {
            get;
            set;
        }
    }

    public class CustomerInfos
    {
        [XmlElement(ElementName = "CustomerInfo")]
        public CustomerInfo[] cs
        {
            get;
            set;
        }
    }

    public class CustomerInfo
    {
        [XmlElement(ElementName = "CustomerId")]
        public string CustomerId { get; set; }

        [XmlElement(ElementName = "BusinessId")]
        public string BusinessId { get; set; }
    }


    public class ScanConfigs
    {
        [XmlElement(ElementName = "BeginTime")]
        public string BeginTime { get; set; }

        [XmlElement(ElementName = "EndTimme")]
        public string EndTimme { get; set; }
    }
}
