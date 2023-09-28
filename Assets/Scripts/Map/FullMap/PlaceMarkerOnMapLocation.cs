using ARLocation;
using UnityEngine;

public class PlaceMarkerOnMapLocation : MonoBehaviour
{
    [SerializeField] private LocationData[] locations;
    private MapHelper mapHelper;

    private void Awake()
    {
        mapHelper = FindObjectOfType<MapHelper>();
    }
    private void Start()
    {
        foreach (var location in locations)
            mapHelper.PutMarkerOnMap(location.Location);
    }
}