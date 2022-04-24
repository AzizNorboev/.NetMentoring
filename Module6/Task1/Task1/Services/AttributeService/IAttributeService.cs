using Provider.Plugins;
using System;
using System.Reflection;
using System.Text;
using Task1.Configurations;
using Task1.Services.ConfigurationService;

namespace Task1.Services.AttributeService
{
    public interface IAttributeService<T> where T : Attribute 
    {
        void Save<T_value>(object attribute, IConfigurationService<ProviderManager> configuration, ProviderManager manager, PropertyInfo property, T_value value);
        void Display(object attribute, IConfigurationService<ProviderManager> configuration, ProviderManager manager, PropertyInfo property);
    }
}