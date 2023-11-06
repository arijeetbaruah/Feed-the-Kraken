using System.Collections.Generic;
using Unity.VisualScripting;

namespace Baruah.Service
{
    public static class ServiceManager
    {
        public static Dictionary<string, IService> registry;

        static ServiceManager()
        {
            registry = new Dictionary<string, IService>();
        }

        public static void Add<T>(T service) where T : IService
        {
            registry.Add(typeof(T).Name, service);
        }

        public static void Remove<T>() where T : IService
        {
            registry.Remove(typeof(T).Name);
        }

        public static T Get<T>() where T : IService
        {
            return (T) registry[typeof(T).Name];
        }
    }
}
