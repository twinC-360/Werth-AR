using TMPro;
using ARLocation;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using System.Collections.Generic;

public class InterestPoint_Display : MonoBehaviour
{
    [SerializeField] private InterestPoint_ScriptableObject interestPoint;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private Transform iconTransform;
    [SerializeField] private float distanceFromPlayer = 1.0f;
    [SerializeField] private GameObject pin;
    [SerializeField] private float showAtDistance = 25f;
    [SerializeField] private float hideAtDistance = 30f;

    private ARLocationManager arLocationManager;
    private Vector3 playerPositionOnGround;
    private Vector3 interestPointPositionOnGround;
    private float distance;
    private Vector3 directionOnGround;
    private static List<InterestPoint_Display> allPois;
    private InterestPoint_Popup interestPoint_Popup;

    private void Awake()
    {
        arLocationManager = FindObjectOfType<ARLocationManager>();
        interestPoint_Popup = FindObjectOfType<InterestPoint_Popup>();
        iconTransform.SetParent(null);
    }
    private void OnEnable()
    {
        PastPresentFutureManager.OnTimeChanged += OnTimeChanged;
        if (allPois == null)
            allPois = new List<InterestPoint_Display>();
        allPois.Add(this);
    }
    private void OnDisable()
    {
        PastPresentFutureManager.OnTimeChanged -= OnTimeChanged;
        if(allPois != null)
            allPois.Remove(this);
    }
    private void Update()
    {
        if (interestPoint == null) return;

        UpdatePositions();
        DisplayDistance();
        PositionIcon();
        ShowHidePin();
    }

    // Show/Hide pin based on distance to player
    private void ShowHidePin()
    {
        if (distance < showAtDistance && iconTransform.gameObject.activeSelf) // Only show when icon is visible, too.
        {
            pin.SetActive(true);
        }
        else if (distance > hideAtDistance || !iconTransform.gameObject.activeSelf)
        {
            pin.SetActive(false);
        }
    }

    private float moveForwardFactor = 0.1f;

    private void LateUpdate()
    {
        // If there is another POI too close, back out. This is not perfect, yet.
        foreach (var otherPoi in allPois)
        {
            if (otherPoi != this 
                && (otherPoi.iconTransform.position - iconTransform.position).sqrMagnitude < 0.25f 
                && otherPoi.distance < distance)
            {
                distanceFromPlayer += distanceFromPlayer * moveForwardFactor;
                //canvasTransform.position += directionOnGround * distanceFromPlayer * 0.5f;
            }
        }
    }

    private void OnTimeChanged(int index)
    {
        iconTransform.gameObject.SetActive(index == 0);
    }
    public void UpdateInterestPoint(InterestPoint_ScriptableObject newInterestPoint)
    {
        interestPoint = newInterestPoint;
        iconImage.sprite = interestPoint.iconSprite;
    }
    private void UpdatePositions()
    {
        playerPositionOnGround = MathUtils.SetY(Camera.main.transform.position, arLocationManager.CurrentGroundY);
        interestPointPositionOnGround = MathUtils.SetY(transform.position, arLocationManager.CurrentGroundY);
    }
    private void DisplayDistance()
    {
        distance = Vector3.Distance(playerPositionOnGround, transform.position);
        distanceText.text = Mathf.RoundToInt(distance) + "m";
    }
    private void PositionIcon()
    {
        directionOnGround = (interestPointPositionOnGround - playerPositionOnGround).normalized;
        //        canvasTransform.position = playerPositionOnGround + (directionOnGround * distanceFromPlayer);
        iconTransform.position = Camera.main.transform.position + Vector3.down + (directionOnGround * distanceFromPlayer);
    }

    public void DisplayPopup()
    {
        interestPoint_Popup.DisplayInterestPoint(interestPoint);
    }
}