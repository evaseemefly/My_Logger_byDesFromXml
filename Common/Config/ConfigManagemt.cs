using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Common.Config
{
    public class ConfigManagemt
    {
        private static Model.Config_Model _config;

        private static Model.Config_Model _init;

        private static Model.PubSub_Model _pubsub;

        private static string _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config.xml");

        /// <summary>
        /// 锁
        /// </summary>
        private static object _lockObj = new object();

        static ConfigManagemt()
        {
            _init = new Model.Config_Model();
            _init.Logger.Level = "DEBUG";
            _init.Logger.ProjectName = "My_Logger";
            _init.Logger.Type = "File";
        }

        public static Model.Config_Model Config
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
                            var old_xml = Common.SerializationHelper.DesFromXML<Model.Config_Model>(_fileName);

                            if (old_xml != null)
                            {
                                var configXML = new XmlDocument();
                                configXML.Load(_fileName);
                                xml = configXML.DocumentElement;
                            }

                            if (old_xml == null || xml.ChildNodes.Count != typeof(Model.Config_Model).GetProperties().Count())
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
