using Provider.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Task2;
using Task2.Services.ConfigurationService;

namespace Task1.Services.ConfigurationService
{

    public class FileConfigurationService : IConfigurationService<ProviderManager>
    {
        const string PROVIDER_TYPE = "File_Configuration_Provider";
        public void Display(ConfigurationItemAttribute configurationAttribute, ProviderManager manager, PropertyInfo property)
        {
            if (manager != null && configurationAttribute.ProviderType == PROVIDER_TYPE)
            {
                manager.LoadSettings(property);
            }
        }

        public void AddValue<TValue>(ConfigurationItemAttribute configurationAttribute, ProviderManager manager, PropertyInfo property, TValue value)
        {
            if (manager != null && configurationAttribute.ProviderType == PROVIDER_TYPE)
            {
                manager.SaveSettings(property, value);
            }
        }
    }
}
