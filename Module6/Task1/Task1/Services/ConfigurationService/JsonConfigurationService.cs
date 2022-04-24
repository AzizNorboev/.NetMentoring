using Provider.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Task1.Configurations;

namespace Task1.Services.ConfigurationService
{
    public class JsonConfigurationService : IConfigurationService<ProviderManager>
    {
        const string PROVIDER_TYPE = "Json_Configuration_Provider";
        public void Display(ConfigurationItemAttribute configurationAttribute, ProviderManager manager, PropertyInfo property)
        {
            if (manager != null && configurationAttribute.ProviderType == PROVIDER_TYPE)
            {
                manager.LoadSettings(property);
            }
        }

        public void AddValue<T>(ConfigurationItemAttribute configurationAttribute, ProviderManager manager, PropertyInfo property, T value)
        {
            if (manager != null && configurationAttribute.ProviderType == PROVIDER_TYPE)
                manager.SaveSettings(property, value);
        }
    }
}
