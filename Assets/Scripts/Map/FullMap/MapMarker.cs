using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapMarker : MonoBehaviour
{
    [SerializeField] private Image markerImage;
    [SerializeField] private TextMeshProUGUI markerName;
    private InterestPoint_Popup interestPoint_Popup;
    private InterestPoint_ScriptableObject interestPoint_ScriptableObject;

    private void Awake()
    {
        interestPoint_Popup = FindObjectOfType<InterestPoint_Popup>();
    }

    public void UpdateMarker(InterestPoint_ScriptableObject interestPoint)
    {
        markerImage.sprite = interestPoint.iconSprite;
        markerName.text = interestPoint.name;
        interestPoint_ScriptableObject = interestPoint;
    }
    public void DisplayPopup()
    {
        interestPoint_Popup.DisplayInterestPoint(interestPoint_ScriptableObject);
    }
}