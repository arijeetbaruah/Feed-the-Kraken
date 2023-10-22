using Baruah.Config;

namespace Baruah.Service
{
    public class ConfigService : IService
    {
        private ConfigRegistry configRegistry;

        public ConfigService(ConfigRegistry configRegistry)
        {
            this.configRegistry = configRegistry;

            configRegistry.Initialize();
        }

        public T Get<T>() where T : class, IConfig, new()
        {
            return configRegistry.TryGet<T>();
        }
    }
}
