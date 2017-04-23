using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_MsgPubSub_byRedis
{
    internal class PubSubRedisProvider : IPubSub
    {
        /// <summary>
        /// 订阅者与发布者对象
        /// 是一个相互关联的组到Redis服务器的连接
        /// 从指定服务器获取 发布者/订阅者 连接
        /// </summary>
        static ISubscriber sub = StackExchange.Redis.ConnectionMultiplexer.Connect(My_Logger.Config.ConfigManagemt.Config.Redis.Host).GetSubscriber();

        #region IPubSub 成员

        #region String对象
        public long Publish(string channel, string value)
        {
            //发送消息到指定频道
            return sub.Publish(channel, value);
        }

        public void Subscribe(string channel, Action<string> action)
        {
            //当执行首选/活动节点的更改时，订阅执行某些操作。
            sub.Subscribe(channel, (c, m) =>
            {
                action(m);
            });

        }

        public long PublishAsync(string channel, string value)
        {
            return sub.PublishAsync(channel, value).Result;
        }

        public void SubscribeAsync(string channel, Action<string> action)
        {
            sub.SubscribeAsync(channel, (c, m) =>
            {
                action(m);
            });
        }

        #endregion

        #region Byte[]对象
        public long PublishByte(string channel, byte[] value)
        {
            return sub.Publish(channel, value);
        }

        public void SubscribeByte(string channel, Action<byte[]> action)
        {
            sub.Subscribe(channel, (c, m) =>
            {
                action(m);
            });
        }

        public long PublishByteAsync(string channel, byte[] value)
        {
            return sub.PublishAsync(channel, value).Result;
        }

        public void SubscribeByteAsync(string channel, Action<byte[]> action)
        {
            sub.SubscribeAsync(channel, (c, m) =>
            {
                action(m);
            });
        }

        #endregion

        #region 泛型对象
        public long Publish<T>(string channel, T value)
        {
            return 0;
            //return sub.Publish(channel, Utils.SerializeMemoryHelper.SerializeToBinary(value));
        }

        public void Subscribe<T>(string channel, Action<T> action)
        {
            sub.Subscribe(channel, (c, m) =>
            {
                //My_Logger.Common.SerializationHelper
                //action((T)Utils.SerializeMemoryHelper.DeserializeFromBinary(m));
            });
        }

        public long PublishAsync<T>(string channel, T value)
        {
            return 0;
            //return sub.PublishAsync(channel, Utils.SerializeMemoryHelper.SerializeToBinary(value)).Result;
        }

        public void SubscribeAsync<T>(string channel, Action<T> action)
        {
            //sub.SubscribeAsync(channel, (c, m) =>
            //{
            //    action((T)Utils.SerializeMemoryHelper.DeserializeFromBinary(m));
            //});
        }
        #endregion

        #endregion

        #region IPubSub 成员


        public void UnSubscribe(string channel)
        {
            sub.Unsubscribe(channel);
        }

        public void UnSubscribeAll()
        {
            sub.UnsubscribeAll();
        }

        #endregion
    }
}