using Microsoft.Extensions.DependencyInjection;
using Provider.Plugins;
using System;
using System.Reflection;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Assembly assembly = typeof(ProviderManager).Assembly;

            Type fileProvidertype = assembly.GetType("Provider.Plugins.FileConfigurationProvider");
            dynamic file = Activator.CreateInstance(fileProvidertype);

            Type configurationManagerConfigurationProvidertype = assembly.GetType("Provider.Plugins.ConfigurationManagerConfigurationProvider");
            dynamic configurationManager = Activator.CreateInstance(configurationManagerConfigurationProvidertype);

            Type jsonConfigurationProviderType = assembly.GetType("Provider.Plugins.JsonConfigurationProvider");
            dynamic jsonConfigurationProvider = Activator.CreateInstance(jsonConfigurationProviderType,
                                                                    BindingFlags.Instance | BindingFlags.Public,
                                                                     null, new object[] { "Json Provider value" }, null);

            var configurationBase_FileConfig = new ConfigurationComponentBase(file);
            var configurationBase_ConfigManager = new ConfigurationComponentBase(configurationManager);
            var configurationBase_JsonConfig = new ConfigurationComponentBase(jsonConfigurationProvider);

            configurationBase_FileConfig.Save(new TimeSpan(20, 20, 21));
            configurationBase_ConfigManager.Save("Manager value11");
            configurationBase_JsonConfig.Save("New Json value11");
            configurationBase_FileConfig.Load();
            configurationBase_ConfigManager.Load();
            configurationBase_JsonConfig.Load();
        }
    }
}
