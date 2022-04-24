using Microsoft.Extensions.DependencyInjection;
using Provider.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using Task1.Services.ConfigurationService;
using Task2.Services.AttributeService;
using Task2.Services.ConfigurationService;

namespace Task2
{
    public class ConfigurationComponentBase
    {

        [ConfigurationItem(SettingName = "Item_Setting", ProviderType = "File_Configuration_Provider")]
        public FileConfigurationProvider FileConfigurationProvider { get; set; } 

        [ConfigurationItem(SettingName = "Configuration_Setting", ProviderType = "Configuration_Manager_Configuration_Provider")]
        public ConfigurationManagerConfigurationProvider ConfigurationManagerConfigurationProvider { get; set; }

        [ConfigurationItem(SettingName = "Json_Setting", ProviderType = "Json_Configuration_Provider")]
        public JsonConfigurationProvider JsonConfigurationProvider { get; set; }

        public ConfigurationComponentBase(FileConfigurationProvider fileConfigurationProvider,
                                          ConfigurationManagerConfigurationProvider configurationManagerConfigurationProvider,
                                          JsonConfigurationProvider jsonConfigurationProvider)
        {
            if (fileConfigurationProvider == null || configurationManagerConfigurationProvider == null || jsonConfigurationProvider == null)
            {
                throw new ArgumentNullException("property cannot be null");
            }
            else
            {
                FileConfigurationProvider = fileConfigurationProvider;
                ConfigurationManagerConfigurationProvider = configurationManagerConfigurationProvider;
                JsonConfigurationProvider = jsonConfigurationProvider;
            }
        }

        public void SaveAppSettings()
        {
                //Attribute Service
                var attributeService = GetAttributeService();

                //Configuration Services
                var configServices = GetConfigService();
                var fileConfigService = configServices.Where(s => s.GetType() == typeof(FileConfigurationService)).FirstOrDefault();
                var jsonConfigService = configServices.Where(s => s.GetType() == typeof(JsonConfigurationService)).FirstOrDefault();
                var managerConfigService = configServices.Where(s => s.GetType() == typeof(ManagerConfigurationService)).FirstOrDefault();

                var properties = this.GetType().GetProperties();

                foreach (var property in properties)
                {
                    var attributes = property.GetCustomAttributes(typeof(ConfigurationItemAttribute), false);

                    foreach (var attribute in attributes)
                    {
                        attributeService.Save(attribute, fileConfigService, FileConfigurationProvider, property, FileConfigurationProvider.Value);
                        attributeService.Save(attribute, managerConfigService, ConfigurationManagerConfigurationProvider, property, ConfigurationManagerConfigurationProvider.Value);
                        attributeService.Save(attribute, jsonConfigService, JsonConfigurationProvider, property, JsonConfigurationProvider.Value);
                    }
                }          
        }

        public void ReadAppSettings()
        {
            //Configuration Services
            var services = GetConfigService();
            var fileConfigService = services.Where(s => s.GetType() == typeof(FileConfigurationService)).FirstOrDefault();
            var jsonConfigService = services.Where(s => s.GetType() == typeof(JsonConfigurationService)).FirstOrDefault();
            var managerConfigService = services.Where(s => s.GetType() == typeof(ManagerConfigurationService)).FirstOrDefault();

            var AttributeService = GetAttributeService();
            var properties = this.GetType().GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(typeof(ConfigurationItemAttribute), false);

                foreach (var attribute in attributes)
                {
                    AttributeService.Display(attribute, fileConfigService, FileConfigurationProvider, property);
                    AttributeService.Display(attribute, managerConfigService, ConfigurationManagerConfigurationProvider, property);
                    AttributeService.Display(attribute, jsonConfigService, JsonConfigurationProvider, property);
                }
            }
        }

        public IEnumerable<IConfigurationService<ProviderManager>> GetConfigService()
        {
            //FileConfiguration service
            var list = new List<IConfigurationService<ProviderManager>>();
            var fileConfigCollection = new ServiceCollection();
            fileConfigCollection.AddScoped<IConfigurationService<ProviderManager>, FileConfigurationService>();

            IServiceProvider fileConfigServiceProvider = fileConfigCollection.BuildServiceProvider();
            var fileConfigService = fileConfigServiceProvider.GetService<IConfigurationService<ProviderManager>>();


            //JsonConfiguration service
            var jsonConfigCollection = new ServiceCollection();
            jsonConfigCollection.AddScoped<IConfigurationService<ProviderManager>, JsonConfigurationService>();

            IServiceProvider jsonConfigServiceProvider = jsonConfigCollection.BuildServiceProvider();
            var jsonConfigService = jsonConfigServiceProvider.GetService<IConfigurationService<ProviderManager>>();

            //ManagerConiguration service
            var managerConfigCollection = new ServiceCollection();
            managerConfigCollection.AddScoped<IConfigurationService<ProviderManager>, ManagerConfigurationService>();

            IServiceProvider managerConfigServiceProvider = managerConfigCollection.BuildServiceProvider();
            var managerConfigService = managerConfigServiceProvider.GetService<IConfigurationService<ProviderManager>>();

            list.Add(fileConfigService);
            list.Add(jsonConfigService);
            list.Add(managerConfigService);
            return list;
        }

        public IAttributeService<ConfigurationItemAttribute> GetAttributeService()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IAttributeService<ConfigurationItemAttribute>, AttributeService.AttributeService>();

            IServiceProvider attributeServiceProvider = collection.BuildServiceProvider();
            var attributeService = attributeServiceProvider.GetService<IAttributeService<ConfigurationItemAttribute>>();
            return attributeService;
        }
    }
}
