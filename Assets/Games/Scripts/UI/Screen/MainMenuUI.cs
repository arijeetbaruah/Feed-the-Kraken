using Baruah.Service;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Baruah.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI welcomePlayer;
        [SerializeField] private UIButton playerBtn;
        [SerializeField] private UIButton quitBtn;

        private async void Start()
        {
            string playerName = await ServiceManager.Get<AuthSystem>().GetPlayerName();
            welcomePlayer.SetText($"Welcome: <color=red>{playerName}</color>");
        }

        private void OnEnable()
        {
            playerBtn.AddListener(PlayBtnClick);
            quitBtn.AddListener(QuitBtnClick);
        }

        private void OnDisable()
        {
            playerBtn.RemoveListener(PlayBtnClick);
            quitBtn.RemoveListener(QuitBtnClick);
        }

        private void PlayBtnClick()
        {
            SceneManager.LoadScene(3);
        }

        private void QuitBtnClick()
        {
            Application.Quit();
        }
    }
}
