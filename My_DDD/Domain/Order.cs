using My_DDD.Enum;
using My_DDD.EventHandler;
using My_DDD.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_DDD.Domain
{
    /// <summary>
    /// 订单实体
    /// </summary>
    public class Order
    {
        event Action<OrderConfirmEvent> handle_confirm;
        event Action<OrderCreateEvent> handle_create;

        /// <summary>
        /// 订单id
        /// </summary>
        public Guid OrderId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 订单状态（枚举）
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// 订单项的导航属性
        /// </summary>
        public IList<OrderItem> OrderItem { get; set; }

        public Order()
        {
            handle_confirm += Order_handle_Confirm;
            handle_create += Order_handle_Create;
        }

        void Order_handle_Confirm(OrderConfirmEvent obj)
        {
            new SendEmailEventHandler().Handle(obj);
        }

        void Order_handle_Create(OrderCreateEvent obj)
        {
            new SendEmailEventHandler().Handle(obj);
        }

        #region 领域事件
        public void Create()
        {
            //事件发布
            handle_create(new OrderCreateEvent { OrderId = Guid.NewGuid(), UserId = 1, ProductName = "电脑" });
        }

        public void Paid() { }

        public void Confirm()
        {
            handle_confirm(new OrderConfirmEvent { OrderId = Guid.NewGuid(), UserId = 1, ConfirmDate = DateTime.Now });
        }

        public void Send() { }

        public void Recivie() { }
        #endregion
    }
}
