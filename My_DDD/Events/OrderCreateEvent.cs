using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_DDD.Events
{
    /// <summary>
    /// 订单创建事件（只保留属性）
    /// </summary>
    public class OrderCreateEvent:EventBase
    {
        /// <summary>
        /// 订单id
        /// </summary>
        public Guid OrderId { get; set; }
        /// <summary>
        /// 商品名字
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 购买者
        /// </summary>
        public int UserId { get; set; }
    }
}
