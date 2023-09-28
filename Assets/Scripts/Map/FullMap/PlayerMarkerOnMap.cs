using ARLocation;
using UnityEngine;

public class PlayerMarkerOnMap : MonoBehaviour
{
    [Header("Player Marker")]
    [SerializeField] private GameObject playerMarkerPrefab;
    [SerializeField] private MapHelper mapHelper;
    private RectTransform playerMarkerRect;
    [SerializeField] Transform ARLocationRoot;
    [SerializeField] Transform ARCamera;
    [SerializeField] float rotationOffset = 75;

    private void Awake()
    {
        mapHelper = FindObjectOfType<MapHelper>();

        GameObject playerMarker = Instantiate(playerMarkerPrefab, transform);
        playerMarkerRect = playerMarker.GetComponent<RectTransform>();
    }
    private void Start()
    {
    }

    private void Update()
    {
        //#if UNITY_EDITOR
        //    UpdatePlayerLocation(testLocation);
        //#else

        if (LoadingManager.useMockLocationData)
        {
            UpdatePlayerLocation(ARLocationManager.Instance.GetLocationForWorldPosition(Camera.main.transform.position));
        } else
            UpdatePlayerLocation(ARLocationProvider.Instance.CurrentLocation.ToLocation());          
        //#endif
    }

    private void UpdatePlayerLocation(Location location)
    {
        mapHelper.PlacePlayerRectAtLocation(playerMarkerRect, location);
        playerMarkerRect.rotation = Quaternion.Euler(0, 0,
            - (ARCamera.rotation.eulerAngles.y - ARLocationRoot.rotation.eulerAngles.y - rotationOffset));

    }
}