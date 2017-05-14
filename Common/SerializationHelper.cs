using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common
{
    public class SerializationHelper
    {
        private static object lockObj = new object();

        public static void SerializeWirte<T>(object obj)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            //TextWriter writer = new StreamWriter(Xmlname);
            TextWriter writer = new StringWriter();
            ser.Serialize(writer, obj);//要序列化的对象
        }

        /// <summary>
        /// 将对象序列化到文件（xml）中
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="obj"></param>
        public static void Serialize2XML(string fileName, object obj)
        {
            lock (lockObj)
            {
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    new XmlSerializer(obj.GetType()).Serialize(fs, obj);
                }
            }
        }

        /// <summary>
        /// 将对象序列化至xml文档中（泛型方法）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <param name="obj"></param>
        public static void Serialize2XML<T>(string fileName, object obj) where T : class
        {
            lock (lockObj)
            {
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    new XmlSerializer(typeof(T)).Serialize(fs, obj);
                }
            }
        }

        /// <summary>
        /// 读取xml文件将其反序列化为对象
        /// （可尝试使用泛型的方式）
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static object DesFromXML(string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    return new XmlSerializer(typeof(object)).Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 读取xml文件将其反序列化为对象
        /// 泛型方法
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T DesFromXML<T>(string fileName) where T : class
        {
            try
            {
                if (!File.Exists(fileName))
                    return null;
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    object result = xs.Deserialize(fs);
                    return result as T;
                    //return new XmlSerializer(typeof(object)).Deserialize(fs) as T;
                }
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
