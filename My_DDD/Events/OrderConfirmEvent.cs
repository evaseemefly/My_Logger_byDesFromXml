using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_DDD.Events
{

    /// <summary>
    /// 订单确认事件（只保留属性）
    /// </summary>
    public class OrderConfirmEvent:EventBase
    {
        /// <summary>
        /// 订单id
        /// </summary>
        public Guid OrderId { get; set; }
        /// <summary>
        /// 确认时间
        /// </summary>
        public DateTime ConfirmDate { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
    }
}
