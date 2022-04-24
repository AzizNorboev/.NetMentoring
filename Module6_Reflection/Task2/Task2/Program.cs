using Provider.Plugins;
using System;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //assemblies
            Assembly fileAssembly = typeof(FileConfigurationProvider).Assembly;
            Assembly configManagerAssembly = typeof(ConfigurationManagerConfigurationProvider).Assembly;
            Assembly jsonAssembly = typeof(JsonConfigurationProvider).Assembly;

            //provider instances
            Type fileProvidertype = fileAssembly.GetType("Provider.Plugins.FileConfigurationProvider");
            dynamic file = Activator.CreateInstance(fileProvidertype, BindingFlags.Instance | BindingFlags.Public,
                                                                    null, new object[] { "new file value1" }, null);

            Type configurationManagerConfigurationProvidertype = configManagerAssembly.GetType("Provider.Plugins.ConfigurationManagerConfigurationProvider");
            dynamic configurationManager = Activator.CreateInstance(configurationManagerConfigurationProvidertype,
                                                                    BindingFlags.Instance | BindingFlags.Public,
                                                                     null, new object[] { new TimeSpan(11, 09, 12) }, null);
            

            Type jsonConfigurationProviderType = jsonAssembly.GetType("Provider.Plugins.JsonConfigurationProvider");
            dynamic jsonConfigurationProvider = Activator.CreateInstance(jsonConfigurationProviderType,
                                                                    BindingFlags.Instance | BindingFlags.Public,
                                                                     null, new object[] { "Json Provider value1" }, null);

            //initializing ConfigurationCoponentBase with provider instances
            var configurationBase = new ConfigurationComponentBase(file, configurationManager, jsonConfigurationProvider);
            try
            {
                configurationBase.SaveAppSettings();
                configurationBase.ReadAppSettings();

            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to save configuration.\n {0}", e.Message);
            }
            Console.ReadLine();
        }
    }
}
