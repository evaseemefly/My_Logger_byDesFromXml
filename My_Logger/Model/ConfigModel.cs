using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace My_Logger.Model
{
    //[XmlRoot("ConfigModel")]
    //[XmlRoot(Namespace = "", IsNullable = false, ElementName = "ConfigModel")]
    public class ConfigModel
    {
        //[XmlElement("Logger")]
        [XmlElement(Order =0)]
        public Logger_Model Logger { get; set; }

        /// <summary>
        /// 在无参构造函数中实例化需要加载的配置对象
        /// </summary>
        public ConfigModel()
        {
            Logger = new Logger_Model();
        }
    }

    #region 注释掉的部分——分离到Logger_Model类中
    //public class Logger_Model
    //{
    //    [DisplayName("日志实现方式：File,Log4net,MongoDB")]
    //    [XmlElement(Order = 0)]
    //    public string Type { get; set; }

    //    [DisplayName("日志级别:Debug|Info|Warn|Erro|Fatal|Off")]
    //    [System.Xml.Serialization.XmlElement(Order = 1)]
    //    public string Level { get; set; }

    //    [DisplayName("日志记录的项目名称")]
    //    [System.Xml.Serialization.XmlElement(Order = 2)]
    //    public string ProjectName { get; set; }
    //}
    #endregion

}
