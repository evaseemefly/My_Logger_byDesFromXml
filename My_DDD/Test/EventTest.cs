using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My_DDD.Domain;

namespace My_DDD.Test
{
    /// <summary>
    /// 事件测试类
    /// </summary>
    public class EventTest
    {
        /// <summary>
        /// 订单确认
        /// </summary>
        public void Confirm()
        {
            var order = new Order();
            //更新数据库
            //repository
            //执行事件
            order.Confirm();            
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        public void Create()
        {
            var order = new Order();
            //插入数据库
            //repository
            //执行事件
            order.Create();
            
        }
    }
}
