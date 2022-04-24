using Provider.Plugins;
using System;
using System.Reflection;
using System.Text;
using Task2.Services.ConfigurationService;

namespace Task2.Services.AttributeService
{
    public interface IAttributeService<T> where T : Attribute 
    {
        void Save<T_value>(object attribute, IConfigurationService<ProviderManager> configuration, ProviderManager manager, 
            PropertyInfo property, T_value value);
        void Display(object attribute, IConfigurationService<ProviderManager> configuration, ProviderManager manager, PropertyInfo property);
    }
}