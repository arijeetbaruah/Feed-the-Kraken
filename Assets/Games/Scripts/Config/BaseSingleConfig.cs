using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Baruah.Config
{
    public abstract class BaseSingleConfig<T, U> : ScriptableObject, IConfig where T : class, IConfigData, new() where U : class, IConfig
    {
        public string ID => typeof(U).Name;

        [HideLabel] public T data;

        public T Data => data;

        public virtual void Initialize()
        {
        }
    }

    public abstract class BaseMultiConfig<T, U> : ScriptableObject, IConfig where T : class, IConfigData, new() where U : class, IConfig
    {
        public string ID => typeof(U).Name;

        [HideLabel, SerializeField] public List<T> data;

        private Dictionary<string, T> map;
        public Dictionary<string, T> Data => map;

        public virtual void Initialize()
        {
            map = new Dictionary<string, T>();
            foreach (var item in data)
            {
                if (!map.TryAdd(item.ID, item))
                {
                    throw new System.Exception($"Duplicate ID {item.ID}: {ID}");
                }
            }
        }
    }
}
