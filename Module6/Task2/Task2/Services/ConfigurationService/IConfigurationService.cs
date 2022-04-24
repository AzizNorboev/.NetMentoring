using Provider.Plugins;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Services.ConfigurationService
{
    public interface IConfigurationService<T> where T : ProviderManager
    {
        public void AddValue<TValue>(ConfigurationItemAttribute configurationAttribute, ProviderManager manager, PropertyInfo property, TValue value);

        public abstract void Display(ConfigurationItemAttribute configurationAttribute, ProviderManager manager,
            PropertyInfo property);
    }
}
