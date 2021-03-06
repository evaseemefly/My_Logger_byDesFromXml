﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace My_MsgPubSub_byRedis
{
    public class PubSubManager:IPubSub
    {
        /// <summary>
        /// 重发次数
        /// </summary>
        private static int repeatNum = My_Logger.Config.ConfigManagemt.Config.PubSub.RepeatNum;

        /// <summary>
        /// 重发间隔
        /// </summary>
        private static int interval = My_Logger.Config.ConfigManagemt.Config.PubSub.Interval;

        private IPubSub pubsub;

        /// <summary>
        /// 私有构造函数
        /// </summary>
        private PubSubManager()
        {
            //pubsub = new PubSubRedisProvider();
            pubsub = Common.ServiceLocator.Instance.GetService<IPubSub>();

        }

        private static PubSubManager instance;

        public static PubSubManager Instance
        {
            get
            {
                return instance ?? (instance = new PubSubManager());
            }
        }

        /// <summary>
        /// 失败后的重试操作
        /// </summary>
        /// <param name="action"></param>
        private void RepeatAction(string channel, Func<bool> action)
        {
            for (int i = 1; i <= repeatNum; i++)
            {
                Thread.Sleep(interval);
                string msg = string.Format("队列管道:{0},发布者发展订阅者有问题，正在重试第{1}次", channel, i);
                Console.WriteLine(msg);
               // Logger.LoggerFactory.Instance.Logger_Warn(msg);
                if (action())
                    break;
            }
        }

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="channel">频道名称</param>
        /// <param name="value">消息内容</param>
        /// <returns></returns>
        public long Publish(string channel, string value)
        {
            if (pubsub.Publish(channel, value) == 0)
            {
                RepeatAction(channel, () =>
                {
                    return pubsub.Publish(channel, value) > 0;
                });
            }
            return 0;
        }

        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="action"></param>
        public void Subscribe(string channel, Action<string> action)
        {
            pubsub.Subscribe(channel, action);
        }

        public long PublishAsync(string channel, string value)
        {
            throw new NotImplementedException();
        }

        public void SubscribeAsync(string channel, Action<string> action)
        {
            throw new NotImplementedException();
        }

        public long PublishByte(string channel, byte[] value)
        {
            if (pubsub.PublishByte(channel, value) == 0)
            {
                //订阅者为0，或者订阅者出现异常，我们可以重试
                RepeatAction(channel, () =>
                {
                    return pubsub.PublishByte(channel, value) > 0;
                });
            }
            return 0;
        }

        public void SubscribeByte(string channel, Action<byte[]> action)
        {
            pubsub.SubscribeByte(channel, action);
        }

        public long PublishByteAsync(string channel, byte[] value)
        {
            throw new NotImplementedException();
        }

        public void SubscribeByteAsync(string channel, Action<byte[]> action)
        {
            throw new NotImplementedException();
        }

        public long Publish<T>(string channel, T value)
        {
            if (pubsub.Publish<T>(channel, value) == 0)
            {
                //订阅者为0，或者订阅者出现异常，我们可以重试
                RepeatAction(channel, () =>
                {
                    return pubsub.Publish<T>(channel, value) > 0;
                });
            }
            return 0;
        }

        public void Subscribe<T>(string channel, Action<T> action)
        {
            pubsub.Subscribe(channel, action);
        }

        public long PublishAsync<T>(string channel, T value)
        {
            throw new NotImplementedException();
        }

        public void SubscribeAsync<T>(string channel, Action<T> action)
        {
            throw new NotImplementedException();
        }

        public void UnSubscribe(string channel)
        {
            throw new NotImplementedException();
        }

        public void UnSubscribeAll()
        {
            throw new NotImplementedException();
        }
    }
}
