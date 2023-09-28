using ARLocation;
using UnityEngine;

public class DistanceCalculation : MonoBehaviour
{
    [SerializeField] private LocationData referencePoint;
    [SerializeField] private GameObject popupWindow;
    [SerializeField] private GameObject arComponents;
    [SerializeField] private float referenceDistance;
    private Location currentLocation;

    private void Awake()
    {
        popupWindow.SetActive(false);
    }
    private void Start()
    {
    }

    private void Update()
    {
        if (LoadingManager.useMockLocationData) return;

        //#if UNITY_EDITOR
        //    currentLocation = testLocation;
        //#else
            currentLocation = ARLocationProvider.Instance.CurrentLocation.ToLocation();
        //#endif

        double distance = Location.DistanceWithAltitude(currentLocation, referencePoint.Location);

        if (distance > referenceDistance)
        {
            popupWindow.SetActive(true);
            arComponents.SetActive(false);
        }
    }
}