using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HotspotBubble : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hotspotText;
    [SerializeField] private GameObject infoHolder;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(() => HideInfo());
        HideInfo();
    }

    public void ShowInfo(string info)
    {
        infoHolder.SetActive(true);
        hotspotText.text = info;
    }
    private void HideInfo()
    {
        infoHolder.SetActive(false);
        hotspotText.text = "";
    }
}