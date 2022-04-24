
using System;

namespace Task1
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigurationItemAttribute : Attribute
    {
        public string SettingName { get; set; } 
        public string ProviderType { get; set; }
    }
}
