using TMPro;
using UnityEngine;

public class RibbonHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ribbonTxt;

    public void SetText(string txt)
    {
        gameObject.SetActive(true);

        ribbonTxt.SetText(txt);
    }
}
