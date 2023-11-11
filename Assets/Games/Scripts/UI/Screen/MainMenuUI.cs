using Baruah.Service;
using TMPro;
using UnityEngine;

namespace Baruah.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI welcomePlayer;
        [SerializeField] private UIButton playerBtn;

        private async void Start()
        {
            string playerName = await ServiceManager.Get<AuthSystem>().GetPlayerName();
            welcomePlayer.SetText($"Welcome: <color=red>{playerName}</color>");
        }
    }
}
