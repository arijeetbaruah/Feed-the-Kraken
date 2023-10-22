using Sirenix.OdinInspector;
using UnityEngine;

namespace Baruah.Config
{
    public class NavigationCardsConfig : BaseMultiConfig<NavigationCardsConfigData, NavigationCardsConfig>
    {
        public static NavigationCardsConfig GetInstance()
        {
#if UNITY_EDITOR
            string[] guids = UnityEditor.AssetDatabase.FindAssets($"t:{typeof(NavigationCardsConfig).Name}");
            string path = UnityEditor.AssetDatabase.GUIDToAssetPath(guids[0]);
            return UnityEditor.AssetDatabase.LoadAssetAtPath<NavigationCardsConfig>(path);
#else
            return null;
#endif
        }
    }

    [System.Serializable]
    public class NavigationCardsConfigData : IConfigData
    {
        public string ID => id.ToString();
        public NavigationDirection id;
        [PreviewField] public NavigationCard cards;
    }
}
