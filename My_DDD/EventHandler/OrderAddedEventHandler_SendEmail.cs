using My_DDD.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_DDD.EventHandler
{
    public class OrderAddedEventHandler_SendEmail : My_DDD.Infrastructure.IEventHandler<OrderGeneratorEvent>
    {
        public void Handle(OrderGeneratorEvent e)
        {
            Console.WriteLine("Order_Number:{0},Send a Email.", e.OrderID);
        }
    }
}
