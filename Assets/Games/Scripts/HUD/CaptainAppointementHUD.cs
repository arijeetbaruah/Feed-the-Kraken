using Baruah;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CaptainAppointementHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt;

    public void ShowCaptain(IPlayer player)
    {
        txt.SetText($"{player.Name} is the Captain!");
    }
}
