
using ARLocation;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ARLocationProvider))]
public class GPSLocationButton_Controller : MonoBehaviour
{
    [SerializeField] private Button gpsButton;
    [SerializeField] private LocationData referencePoint;
    [SerializeField] private LocationData testLocation;
    [SerializeField] private float referenceDistance;
    private Location currentLocation;

    private void Update()
    {
        //#if UNITY_EDITOR
        //    currentLocation = testLocation.Location;
        //#else
            currentLocation = ARLocationProvider.Instance.CurrentLocation.ToLocation();
        //#endif

        gpsButton.interactable = Location.DistanceWithAltitude(currentLocation, referencePoint.Location) <= referenceDistance;
    }
}