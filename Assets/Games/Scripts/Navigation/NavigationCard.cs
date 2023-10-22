using Baruah.Config;
using Baruah.Service;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Baruah
{
    public enum NavigationDirection
    {
        NORTH,
        EAST,
        WEST
    }

    public class NavigationCard : MonoBehaviour
    {
        [SerializeField] private NavigationDirection directionCard;
        [SerializeField, ValueDropdown(nameof(GetActions))] private string navigationAction;
        [SerializeField] private Image[] actionIcon;

        public void SetCardData(NavigatinCardConfigData configData)
        {
            navigationAction = configData.navigationAction;
            directionCard = System.Enum.Parse<NavigationDirection>(configData.navigationDirection);

            if (ServiceManager.Get<ConfigService>().Get<NavigationActionConfig>().Data.TryGetValue(configData.navigationAction, out var actionData))
            {
                foreach(var icon in actionIcon)
                {
                    icon.sprite = actionData.icon;
                }
            }
        }

        public void OnClick()
        {
            NavigationCardSelector.Instance.RemoveCards();
            Ship ship = GameObject.FindObjectOfType<Ship>();
            
            switch(directionCard)
            {
                case NavigationDirection.NORTH:
                    ship.MoveForward();
                    break;
                case NavigationDirection.EAST:
                    ship.MoveLeft();
                    break;
                case NavigationDirection.WEST:
                    ship.MoveRight();
                    break;
            }
        }

        public static IEnumerable<string> GetActions()
        {
            return NavigationActionConfig.GetInstance().data.Select(d => d.ID).ToList();
        }
    }
}
