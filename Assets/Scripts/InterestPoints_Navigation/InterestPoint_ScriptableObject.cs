using ARLocation;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Interest Point", menuName = "Interest Points")]
public class InterestPoint_ScriptableObject : ScriptableObject
{
    [Header("Icon Data")]
    [SerializeField] public Sprite iconSprite;
    [SerializeField] public string placeName;

    [Header("Location")]
    [SerializeField] public LocationData locationData;

    [Header("Interest Point Data")]
//    [SerializeField] public Sprite interestPointPhoto;
    [SerializeField] public Sprite[] interestPointPhotoLocalized;

    [TextArea(10, 100)] [SerializeField] public string interestPointDescription;
}