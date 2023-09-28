using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPointButton : MonoBehaviour
{
    [SerializeField]
    private InterestPoint_ScriptableObject interestPoint_ScriptableObject;

    public void OnEnable()
    {
        GetComponentInParent<Canvas>().worldCamera = Camera.main;
    }

    public void DisplayPopup()
    {
        Debug.Log("DisplayPopup!", this);
        FindObjectOfType<InterestPoint_Popup>()?.DisplayInterestPoint(interestPoint_ScriptableObject);
    }

}
