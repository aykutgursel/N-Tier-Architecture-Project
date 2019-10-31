using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml;
using web.GurselFramework.Framework.Constant;

namespace web.GurselFramework.Core.Configuration
{
    public class ConfigHelper : IConfigurationSectionHandler
    {
        private static bool _initialized { get; set; }
        public static Dictionary<string, string> ConfigList { get; set; }

        static ConfigHelper()
        {
            Initialized();
        }

        private static void Initialized()
        {
            if (!_initialized)
            {
                ConfigList = new Dictionary<string, string>();

                var sectionName = ConfigurationManager.AppSettings.Get(Constants.CONFIG_SECTION_NAME);
                if (!string.IsNullOrEmpty(sectionName))
                {
                    var spliSection = sectionName.Split(',').ToList();
                    if (spliSection.Any())
                    {
                        spliSection.ForEach(section =>
                        {
                            ConfigurationManager.GetSection(section);
                        });

                        _initialized = true;
                    }
                }
            }
        }

        public object Create(object parent, object configContext, XmlNode section)
        {
            var name = section.Name != "GurselConfig" ? $"{section.Name}:" : string.Empty;

            foreach (XmlNode node in section.ChildNodes)
            {
                XmlAttribute attribute = node.Attributes[Constants.VALUE];
                if (attribute != null)
                {
                    ConfigList.Add(name + node.Name, attribute.Value);
                }
            }

            return null;
        }
    }
}
