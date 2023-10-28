using Baruah.Config;
using Baruah.Service;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        [SerializeField, ValueDropdown(nameof(GetActionList))] private string action;

        public IEnumerable<MethodInfo> MoveFunction => typeof(Ship).GetMethods().Where(method => method.GetCustomAttributes<MoveActionAttribute>().Count() > 0);

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

            var funcs = MoveFunction.ToDictionary(m => m.Name);

            funcs[action].Invoke(ship, null);

            /*switch(directionCard)
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
            }*/
        }

        public IEnumerable<string> GetActionList()
        {
            return MoveFunction.Select(method => method.Name);
        }

        public static IEnumerable<string> GetActions()
        {
            return NavigationActionConfig.GetInstance().data.Select(d => d.ID).ToList();
        }
    }
}
