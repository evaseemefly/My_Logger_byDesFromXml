using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_DDD.Infrastructure
{
    /// <summary>
    /// 事件处理接口
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    public interface IEventHandler<TEvent> where TEvent:IEvent
    {
        /// <summary>
        /// 处理程序
        /// </summary>
        /// <param name="e"></param>
        void Handle(TEvent e);
    }
}
