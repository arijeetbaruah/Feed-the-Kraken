using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Baruah.Config
{
    public class NavigationActionConfig : BaseMultiConfig<NavigationActionConfigData, NavigationActionConfig>
    {
        public static NavigationActionConfig GetInstance()
        {
#if UNITY_EDITOR
            string[] guids = UnityEditor.AssetDatabase.FindAssets($"t:{typeof(NavigationActionConfig).Name}");
            string path = UnityEditor.AssetDatabase.GUIDToAssetPath(guids[0]);
            return UnityEditor.AssetDatabase.LoadAssetAtPath<NavigationActionConfig>(path);
#else
            return null;
#endif
        }
    }

    [System.Serializable]
    public class NavigationActionConfigData : IConfigData
    {
        public string ID => id;

        public string id;
        [PreviewField] public Sprite icon;
        [TextArea] public string description;
        [SerializeReference] public INavigationAction navigationAction;
    }
}
