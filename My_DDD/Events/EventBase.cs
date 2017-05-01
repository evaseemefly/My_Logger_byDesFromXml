using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My_DDD.Infrastructure;

namespace My_DDD.Events
{
    /// <summary>
    /// 基础事件中的属性只能在构造函数中初始化
    /// </summary>
    public class EventBase:IEvent
    {
        public EventBase()
        {
            this.RootId = Guid.NewGuid();
            this.EventDate = DateTime.Now;
        }

        /// <summary>
        /// 根id
        /// </summary>
        public Guid RootId { get; private set; }

        /// <summary>
        /// 领域事件处理的时间
        /// </summary>
        public DateTime EventDate { get; private set; }
    }
}
