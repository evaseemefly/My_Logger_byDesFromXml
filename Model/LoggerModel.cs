using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    public partial class LoggerModel
    {
        [DisplayName("日志实现方式：File,Log4net,MongoDB")]
        [XmlElement(Order = 0)]
        public string Type { get; set; }

        [DisplayName("日志级别:Debug|Info|Warn|Erro|Fatal|Off")]
        [System.Xml.Serialization.XmlElement(Order = 1)]
        public string Level { get; set; }

        [DisplayName("日志记录的项目名称")]
        [System.Xml.Serialization.XmlElement(Order = 2)]
        public string ProjectName { get; set; }
    }
}
