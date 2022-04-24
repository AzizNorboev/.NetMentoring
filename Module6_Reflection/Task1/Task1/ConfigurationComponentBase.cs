using Microsoft.Extensions.DependencyInjection;
using Provider.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using Task1.Configurations;
using Task1.Services.AttributeService;
using Task1.Services.ConfigurationService;

namespace Task1
{
    public class ConfigurationComponentBase
    {

        [ConfigurationItem(SettingName = "File_Setting", ProviderType = "File_Configuration_Provider")]
        public FileConfigurationProvider FileConfigurationProvider { get; set; }

        [ConfigurationItem(SettingName = "Manager_Setting", ProviderType = "Configuration_Manager_Configuration_Provider")]
        public ConfigurationManagerConfigurationProvider ConfigurationManagerConfigurationProvider { get; set; }

        [ConfigurationItem(SettingName = "Json_Setting", ProviderType = "Json_Configuration_Provider")]
        public JsonConfigurationProvider JsonConfigurationProvider { get; set; }
        
        public ConfigurationComponentBase(FileConfigurationProvider fileConfigurationProvider)
        {
            FileConfigurationProvider = fileConfigurationProvider;
        }
        public ConfigurationComponentBase(ConfigurationManagerConfigurationProvider configurationManagerConfigurationProvider)
        {
            ConfigurationManagerConfigurationProvider = configurationManagerConfigurationProvider;
        }
        public ConfigurationComponentBase(JsonConfigurationProvider jsonConfigurationProvider)
        {
            JsonConfigurationProvider = jsonConfigurationProvider;
        }

        public void Save<T>(T value)
        {
            //Attribute Service
            var attributeService = GetAttributeService();

            //Configuration Services
            var configServices = GetConfigService();
            var fileConfigService = configServices.Where(s => s.GetType() == typeof(FileConfigurationService)).FirstOrDefault();
            var jsonConfigService = configServices.Where(s => s.GetType() == typeof(JsonConfigurationService)).FirstOrDefault();
            var managerConfigService = configServices.Where(s => s.GetType() == typeof(ManagerConfigurationService)).FirstOrDefault();

            var properties = GetType().GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(typeof(ConfigurationItemAttribute), false);

                foreach (var attribute in attributes)
                {
                    attributeService.Save(attribute, fileConfigService, FileConfigurationProvider, property, value);
                    attributeService.Save(attribute, managerConfigService, ConfigurationManagerConfigurationProvider, property, value);
                    attributeService.Save(attribute, jsonConfigService, JsonConfigurationProvider, property, value);
                }
            }


        }
        public void Load()
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
            collection.AddScoped<IAttributeService<ConfigurationItemAttribute>, AttributeService>();

            IServiceProvider attributeServiceProvider = collection.BuildServiceProvider();
            var attributeService = attributeServiceProvider.GetService<IAttributeService<ConfigurationItemAttribute>>();
            return attributeService;
        }

    }
}
