using Provider.Plugins;
using System;
using System.Reflection;
using Task2.Services.AttributeService;
using Task2.Services.ConfigurationService;

namespace Task2.AttributeService
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

        public void Save<T_value>(object attribute, IConfigurationService<ProviderManager> configuration, ProviderManager manager, 
            PropertyInfo property, T_value value)
        {
            if (attribute is ConfigurationItemAttribute configAttribute && value != null)
            {
                configuration.AddValue(configAttribute, manager, property, value);
            }
        }
    }
}
