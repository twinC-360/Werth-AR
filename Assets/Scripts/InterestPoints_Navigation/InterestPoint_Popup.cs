using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterestPoint_Popup : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private GameObject popupHolder;
    [SerializeField] private GameObject[] objectToDeactivate;

    [Header("UI Elements")]
    [SerializeField] private Image interestPointImage;
    //[SerializeField] private TextMeshProUGUI interestPointDescription;

    public void DisplayInterestPoint(InterestPoint_ScriptableObject interestPoint)
    {
        popupHolder.SetActive(true);
        foreach (var obj in objectToDeactivate)
            obj.SetActive(false);


        interestPointImage.sprite = interestPoint.interestPointPhotoLocalized[ConvertLocaleCode()];

        //interestPointImage.sprite = interestPoint.interestPointPhoto;
        //interestPointDescription.text = interestPoint.interestPointDescription;
    }

    public void ClosePopup()
    {
        foreach (var obj in objectToDeactivate)
            obj.SetActive(true);

        popupHolder.SetActive(false);
    }

    /// <summary>
    /// return image array index for given locale code
    /// </summary>
    /// <returns></returns>
    private int ConvertLocaleCode()
    {
        switch (LocalizationManager.ActiveLocale.Identifier.Code)
        {
            case "en":
                return 0;
            case "de":
                return 1;
            case "nl":
                return 2;
            case "tr":
                return 3;
            case "ar":
                return 4;
            default:
                return 0;
        }
    }

}