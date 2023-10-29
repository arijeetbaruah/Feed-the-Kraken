using Baruah;
using Baruah.Service;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MutanyHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerTxt;
    [SerializeField] private Slider gunUsed;
    [SerializeField] private TextMeshProUGUI gunUsedTxt;

    private int selectedGun = 0;

    private void Start()
    {
        IPlayer player = ServiceManager.Get<PlayerService>().GetPlayers().Where(p => p is LocalPlayer).First();
        gunUsed.maxValue = player.TotalGuns;
        gunUsedTxt.SetText($"0/{player.TotalGuns}");
        selectedGun = 0;

        gunUsed.onValueChanged.AddListener(val =>
        {
            selectedGun = (int)val;
            gunUsedTxt.SetText($"{selectedGun}/{player.TotalGuns}");
        });
    }

    public void SetTimerTxt(int time)
    {
        timerTxt.SetText($"Time: {time}");
    }
}
