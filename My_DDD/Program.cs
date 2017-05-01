using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My_DDD.Test;
using My_DDD.EventHandler;
using My_DDD.Infrastructure;
using My_DDD.Domain;
using My_DDD.Events;

namespace My_DDD
{
    class Program
    {
        static void Main(string[] args)
        {
            //不使用mvc的方式
            //测试
            EventTest test = new EventTest();
            test.Confirm();
            test.Create();

            Infrastructure.EventBus.Instance.Subscribe(new OrderAddedEventHandler_SendEmail());
            //var entity = new OrderGeneratorEvent { OrderID = 1 };
            //var entity = new OrderItem { ItemId = new Guid(), Price = 100, ProductId = 1 };
            var events =new My_DDD.Events.OrderConfirmEvent(){  OrderId=new Guid(), UserId=1};
            Console.WriteLine("生成一个订单，单号为{0}", events.OrderId);
            EventBus.Instance.Publish(events);
            
            Console.ReadLine();
        }

        
    }
}
