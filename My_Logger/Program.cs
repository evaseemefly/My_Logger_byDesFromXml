using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace My_Logger
{
    class Program
    {
        static string _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config.xml");
        static void Main(string[] args)
        {
            //使用别人的测试
            //测试可行
            #region 
            //object result = null;
            //if (File.Exists(_fileName))
            //{
            //    //using (StreamReader reader = new StreamReader(_fileName))
            //    using (FileStream reader = new FileStream(_fileName, FileMode.OpenOrCreate))
            //    {
            //        //XmlSerializer xs = new XmlSerializer(typeof(Model.Config));
            //        XmlSerializer xs = new XmlSerializer(typeof(Model.ConfigModel));
            //        result = xs.Deserialize(reader);
            //    }
            //}
            #endregion
            
            //var config_other_test = Common.SerializationHelper.DesFromXML<Model.Config>(_fileName);
            var config1 = Config.ConfigManagemt.Config;

            //测试由对象写入到xml文件中
            #region 测试由对象写入到xml文件中
            //var config2 = new Model.ConfigModel() { Logger = new Model.Logger_Model {
            //    Level = "DEBUG",
            //    ProjectName = "ceshi",
            //    Type = "File"
            //} };
            //Common.SerializationHelper.SerializeWirte<Model.ConfigModel>(config2);
            #endregion

        }
    }
}
