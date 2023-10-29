using Baruah;
using Baruah.Service;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppointmentNavigationTeamHUD : MonoBehaviour
{
    [SerializeField] private Button btnPrefab;
    [SerializeField] private Transform content;

    [SerializeField] private TextMeshProUGUI viceCaptainTxt;
    [SerializeField] private TextMeshProUGUI navigatorTxt;

    private Dictionary<string, Button> buttonList = new Dictionary<string, Button>();
    private IEnumerable<IPlayer> playerList => ServiceManager.Get<PlayerService>().GetPlayers();
    private IPlayer viceCaptain = null;
    private IPlayer navigator = null;

    private void Start()
    {
        viceCaptainTxt.gameObject.SetActive(false);
        navigatorTxt.gameObject.SetActive(false);

        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        buttonList.Clear();
        foreach (IPlayer player in playerList.Where(player => player.Role != Role.CAPTAIN))
        {
            Button btn = Instantiate(btnPrefab, content);
            string playerID = player.ID;
            btn.GetComponentInChildren<TextMeshProUGUI>().SetText(player.Name);
            buttonList.Add(playerID, btn);
            btn.onClick.AddListener(() =>
            {
                OnButtonClick(playerID);
            });
        }
    }

    private void OnButtonClick(string id)
    {
        TextMeshProUGUI txt = buttonList[id].GetComponentInChildren<TextMeshProUGUI>();
        IPlayer player = playerList.Where(p => p.ID == id).FirstOrDefault();
        if (viceCaptain == null)
        {
            player.Role = Role.VICE_CAPTAIN;
            viceCaptain = player;
        }
        else
        {
            player.Role = Role.NAVIGATOR;
            navigator = player;
        }

        if (player != null)
        {
            string role = player.Role == Role.NONE ? "" : $"({ (player.Role == Role.VICE_CAPTAIN ? "Vice Captain" : "Navigator") })";
            txt.SetText($"{txt.text} {role}");
        }

        if (navigator != null)
        {
            viceCaptainTxt.gameObject.SetActive(true);
            navigatorTxt.gameObject.SetActive(true);
            content.parent.gameObject.SetActive(false);

            viceCaptainTxt.SetText($"{viceCaptain.Name} is Vice Captain");
            navigatorTxt.SetText($"{navigator.Name} is Navigator");

            ServiceManager.Get<UIService>().OnNavigatorSelected.Invoke();
        }
    }

    public void ShowViceCaptainAndNavigator(IPlayer viceCaptain, IPlayer navigator)
    {
        this.viceCaptain = viceCaptain;
        this.navigator = navigator;

        viceCaptainTxt.gameObject.SetActive(true);
        navigatorTxt.gameObject.SetActive(true);
        content.parent.gameObject.SetActive(false);

        viceCaptainTxt.SetText($"{viceCaptain.Name} is Vice Captain");
        navigatorTxt.SetText($"{navigator.Name} is Navigator");

        DOVirtual.DelayedCall(2, () =>
        {
            viceCaptainTxt.gameObject.SetActive(true);
            navigatorTxt.gameObject.SetActive(true);
            ServiceManager.Get<UIService>().OnNavigatorSelected.Invoke();
        });
    }
}
