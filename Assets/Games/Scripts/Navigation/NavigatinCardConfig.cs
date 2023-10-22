using Baruah.Config;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;

namespace Baruah
{
    public class NavigatinCardConfig : BaseMultiConfig<NavigatinCardConfigData, NavigatinCardConfig>
    {
        
    }

    [System.Serializable]
    public class NavigatinCardConfigData : IConfigData
    {
        [ShowInInspector] public string ID => $"{navigationAction}_{navigationDirection}";

        [ValueDropdown(nameof(GetNavigationAction))] public string navigationAction;
        [ValueDropdown(nameof(GetNavigationCardsConfig))] public string navigationDirection;
        public int count;

        private IEnumerable<string> GetNavigationAction()
        {
            return NavigationActionConfig.GetInstance().data.Select(d => d.ID);
        }

        private IEnumerable<string> GetNavigationCardsConfig()
        {
            return NavigationCardsConfig.GetInstance().data.Select(d => d.ID);
        }
    }
}
