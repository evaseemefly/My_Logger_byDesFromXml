using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My_DDD.Events;

namespace My_DDD.EventHandler
{
    public class SendSMSEventHandler :
        //IEventHandler<OrderConfirmEvent>,
        //IEventHandler<OrderCreateEvent>
        My_DDD.Infrastructure.IEventHandler<OrderConfirmEvent>,
        My_DDD.Infrastructure.IEventHandler<OrderCreateEvent>
    {
        public void Action(OrderCreateEvent t)
        {
            throw new NotImplementedException();
        }

        public void Action(OrderConfirmEvent t)
        {
            throw new NotImplementedException();
        }

        public void Handle(OrderCreateEvent e)
        {
            throw new NotImplementedException();
        }

        public void Handle(OrderConfirmEvent e)
        {
            throw new NotImplementedException();
        }
    }
}
