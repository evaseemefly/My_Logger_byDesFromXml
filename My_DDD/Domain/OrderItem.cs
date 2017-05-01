using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_DDD.Domain
{
    /// <summary>
    /// 订单项
    /// </summary>
   public class OrderItem
    {
        /// <summary>
        /// 订单项id
        /// </summary>
        public Guid ItemId { get; set; }
        /// <summary>
        /// 产品id
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
    }
}
