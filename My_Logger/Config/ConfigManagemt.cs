using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace My_Logger.Config
{

    public class ConfigManagemt
    {
        private static Model.ConfigModel _config;

        private static Model.ConfigModel _init;

        private static Model.PubSub_Model _pubsub;

        private static string _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config.xml");

        /// <summary>
        /// 锁
        /// </summary>
        private static object _lockObj = new object();

        static ConfigManagemt()
        {
            _init = new Model.ConfigModel();
            //_init.Logger.Level = "DEBUG";
            //_init.Logger.ProjectName = "My_Logger";
            //_init.Logger.Type = "File";
        }

        public static Model.ConfigModel Config
        {
            get
            {
                if (_config == null)
                {
                    lock (_lockObj)
                    {
                        if (_config == null)
                        {
                            XmlElement xml = null;
                            var old_xml = Common.SerializationHelper.DesFromXML<Model.ConfigModel>(_fileName);

                            if (old_xml != null)
                            {
                                var configXML = new XmlDocument();
                                configXML.Load(_fileName);
                                xml = configXML.DocumentElement;
                            }

                            if (old_xml == null || xml.ChildNodes.Count != typeof(Model.ConfigModel).GetProperties().Count())
                            {
                                Common.SerializationHelper.Serialize2XML(_fileName, _init);
                                _config = _init;
                            }
                            else
                            {
                                _config = old_xml;
                            }
                        }
                    }
                    
                }
                return _config;
            }
        }
    }
}
