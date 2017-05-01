using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_DDD.Infrastructure
{
    public class OrderGeneratorEvent:IEvent
    {
        public int OrderID { get; set; }
    }
}
