using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace My_MsgPubSub_byRedis
{
    class Program
    {
         
            
        static void Main(string[] args)
        {
            //
            Console.WriteLine("请输入命令");
            Console.WriteLine("1为订阅;");
            Console.WriteLine("2为发布");
            Console.WriteLine("3为通过se测试redis");
           var read= Console.ReadLine();
            switch (read)
            {
                case "1":
                    PubSubManager.Instance.Subscribe("mypub", (msg) =>
                    {
                        Console.WriteLine(msg);
                    });
                    break;
                case "2":
                    PubSubManager.Instance.Publish("mypub", "我的消息队列启动了");
                    break;
                case "3":
                    TestRedis();
                    break;
                default:
                    break;
            }
            

            
            Console.ReadLine();
        }

        static void TestRedis()
        {
            RedisManager.Instance.GetDatabase().SetAdd("test", "ceshi1");


        }
    }
}
