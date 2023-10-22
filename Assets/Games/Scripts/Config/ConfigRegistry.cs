using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Baruah.Config
{
    public interface IConfig
    {
        void Initialize();
    }

    public interface IConfigData
    {
        string ID { get; }
    }

    [CreateAssetMenu]
    public class ConfigRegistry : SerializedScriptableObject
    {
        [SerializeField, FolderPath] private string configPath;
        [OdinSerialize, PropertyOrder(1), InlineEditor] private List<IConfig> configs = new List<IConfig>();

        private Dictionary<string, IConfig> configRegistry;

        public void Initialize()
        {
            foreach(IConfig config in configs)
            {
                config.Initialize();
            }

            configRegistry = configs.ToDictionary(c => c.GetType().Name);
        }

        public bool TryGet(string key, out IConfig config)
        {
            return configRegistry.TryGetValue(key, out config);
        }

        public T TryGet<T>() where T : class, IConfig, new()
        {
            if (TryGet(typeof(T).Name, out var config))
            {
                return (T)config;
            }
            
            return null;
        }

        [Button, PropertyOrder(0)]
        public void Generate()
        {
            Type configType = typeof(IConfig);
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(asm => asm.GetTypes()).Where(type => configType.IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface);
            configs.Clear();

            foreach (var type in types)
            {
                string path = $"{configPath}/{type.Name}.asset";
                IConfig config = (IConfig) UnityEditor.AssetDatabase.LoadAssetAtPath(path, type);
                if (config == null)
                {
                    config = ScriptableObject.CreateInstance(type) as IConfig;
                    UnityEditor.AssetDatabase.CreateAsset((UnityEngine.Object)config, path);
                }

                configs.Add(config);
                UnityEditor.EditorUtility.SetDirty(this);
                UnityEditor.AssetDatabase.SaveAssets();
            }
        }
    }
}
