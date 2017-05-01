using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_DDD.Enum
{
    public enum OrderStatus
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        [Description("用户下单")]
        Created = 0,
        /// <summary>
        /// 订单取消
        /// </summary>
        [Description("取消订单")]
        Cancel,
        /// <summary>
        /// 确认
        /// </summary>
        Confirm,
        /// <summary>
        /// 付款
        /// </summary>
        [Description("付款")]
        Paid,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("已发货")]
        Dispatched,
        [Description("订单完成")]
        Finished
    }
}
