using Provider.Plugins;
using System;
using System.Reflection;
using Task1.Configurations;
using Task1.Services.ConfigurationService;

namespace Task1.Services.AttributeService
{
    public class AttributeService : IAttributeService<ConfigurationItemAttribute>
    {
        public void Display(object attribute, IConfigurationService<ProviderManager> configuration, ProviderManager manager, PropertyInfo property)
        {
            if (attribute is ConfigurationItemAttribute configAttribute)
            {
                configuration.Display(configAttribute, manager, property);
            }
        }

        public void Save<T_value>(object attribute, IConfigurationService<ProviderManager> configuration, ProviderManager manager, PropertyInfo property, T_value value)
        {
            if (attribute is ConfigurationItemAttribute configAttribute)
            {
                configuration.AddValue(configAttribute, manager, property, value);
            }
        }
    }
}
