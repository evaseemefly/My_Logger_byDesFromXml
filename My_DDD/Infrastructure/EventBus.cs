using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_DDD.Infrastructure
{
   public class EventBus
    {
        private EventBus()
        {

        }

        private static EventBus _eventBus = null;

        private readonly object sync = new object();

        /// <summary>
        /// 对于事件数据的存储，目前采用内存字典
        /// </summary>
        private static Dictionary<Type, List<object>> eventHandler = new Dictionary<Type, List<object>>();

        private readonly Func<object,object,bool> eventHandlerEquals = (o1, o2) =>
        {
            var o1Type = o1.GetType();
            var o2Type = o2.GetType();
            if(o1Type.IsGenericType&&o1Type.GetGenericTypeDefinition()==typeof(ActionDelegatedEventHandler))
        }
    }
}
