using UnityEngine;

public class HotspotObject : MonoBehaviour
{
    [SerializeField] private string infoText;
    private HotspotBubble hotspotBubble;

    private void Awake()
    {
        hotspotBubble = FindObjectOfType<HotspotBubble>();
    }

    public void ShowInfo()
    {
        hotspotBubble.ShowInfo(infoText);
    }
}   