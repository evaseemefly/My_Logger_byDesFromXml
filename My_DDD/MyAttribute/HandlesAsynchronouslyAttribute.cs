using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_DDD.MyAttribute
{
    /// <summary>
    /// 异步处理事件
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class HandlesAsynchronouslyAttribute : Attribute
    {

    }
}
