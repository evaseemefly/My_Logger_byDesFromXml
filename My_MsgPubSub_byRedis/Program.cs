using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Redis;
using System.Threading;

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
            Console.WriteLine("4为通过se测试多线程写入redis");
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
                case "4":
                    ThreadTest();
                    break;
                default:
                    break;
            }
            

            
            Console.ReadLine();
        }

        static void TestRedis()
        {
            StringRedisHelper.Set("test", "测试");
            Console.WriteLine(StringRedisHelper.Get("test"));
            //RedisManager.Instance.GetDatabase().StringSet("test", "ceshi1");
            //if(RedisManager.Instance.GetDatabase().KeyExists("test"))
            //Console.WriteLine(RedisManager.Instance.GetDatabase().StringGet("test"));

        }

        /// <summary>
        /// 多线程访问redis客户端
        /// </summary>
        static void ThreadTest()
        {
            Thread[] threads = new Thread[10];
            int index = 0;            
            for (int i = 0; i < 10; i++)
            {
                index++;
                threads[i] = new Thread(() => StringRedisHelper.Set(index.ToString(), "线程" + index));
                Console.WriteLine(index.ToString()+"："+index+"写入成功");
            }

            for (int i = 0; i < 10; i++)
            {
                threads[i].Start();
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("取出"+i+"为："+ StringRedisHelper.Get(i.ToString()));  
            }

            //from th in threads
            //select ()=> { index++;
            //    th = new Thread(() => StringRedisHelper.Set(index.ToString(), "线程" + index));}(
                
            //);
        }
    }
}
