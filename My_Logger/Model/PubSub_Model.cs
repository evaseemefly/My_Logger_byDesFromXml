using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Logger.Model
{
    public class PubSub_Model
    {
        #region 分布式Pub/Sub
        /// <summary>
        /// pub端重发的时间间隔
        /// </summary>
        [DisplayName("pub端重发的时间间隔")]
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public int Interval { get; set; }
        /// <summary>
        /// pub端的重发次数
        /// </summary>
        [DisplayName("pub端的重发次数")]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public int RepeatNum { get; set; }
        #endregion
    }
}
