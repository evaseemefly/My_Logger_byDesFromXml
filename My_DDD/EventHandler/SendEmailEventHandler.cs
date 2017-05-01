using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My_DDD.Events;
using My_DDD.Infrastructure;

namespace My_DDD.EventHandler
{
    /// <summary>
    /// 发Email的事件处理程序
    /// </summary>
    public class SendEmailEventHandler :
        My_DDD.Infrastructure.IEventHandler<OrderConfirmEvent>,
        My_DDD.Infrastructure.IEventHandler<OrderCreateEvent>
    {
        static string prefix = "本消息来自电子邮件";

        ///// <summary>
        ///// 处理——创建订单事件
        ///// </summary>
        ///// <param name="t"></param>
        //public void Action(OrderCreateEvent t)
        //{
        //    Console.WriteLine("Email:这个订单{ 0}被{ 1} 建立了,购买了商品 + { 2}——[3]",t.OrderId,t.UserId,
        //    t.ProductName,prefix);
           
        //}

        ///// <summary>
        ///// 处理——确认订单事件
        ///// </summary>
        ///// <param name="t"></param>
        //public void Action(OrderConfirmEvent t)
        //{
        //    Console.WriteLine("Email:这个订单{0}  被 {1}+   在{2}   + 被确认了——[3]", t.OrderId,t.UserId,t.ConfirmDate,prefix);
            
        //}

        /// <summary>
        /// 处理——创建订单事件
        /// </summary>
        /// <param name="e"></param>
        public void Handle(OrderCreateEvent e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 处理——确认订单事件
        /// </summary>
        /// <param name="e"></param>
        public void Handle(OrderConfirmEvent e)
        {
            Console.WriteLine("Email:这个订单{0}  被 {1}+   在{2}   + 被确认了——[3]", e.OrderId, e.UserId, e.ConfirmDate, prefix);
        }
    }
}
