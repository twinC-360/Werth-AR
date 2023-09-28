using ARLocation;
using UnityEngine;

public class MinimapCenter : MonoBehaviour
{
    [Header("Rect")]
    [SerializeField] private RectTransform minimapContent;

    //[Header ("Locations")]
    //[SerializeField] private LocationData centerMapLocation;
    //private Location testLocation;

    [Header("Parameters")]
    [SerializeField] private float mapScaling;

    [Header("Map Helper")]
    [SerializeField] private MapHelper mapHelper;
    private Location playerLocation;

    private void Start()
    {
//        testLocation = InitialLocation.currentInitialLocation;
    }
    private void Update()
    {
        //#if UNITY_EDITOR
        //    playerLocation = testLocation;
        //#else
        if (LoadingManager.useMockLocationData)
        {
            playerLocation = ARLocationManager.Instance.GetLocationForWorldPosition(Camera.main.transform.position);
        }
        else
            playerLocation = ARLocationProvider.Instance.CurrentLocation.ToLocation();
//        #endif

        MoveMapToPlayer(playerLocation);
    }

    private void MoveMapToPlayer(Location playerLocation)
    {
        Vector2 offset = mapHelper.GetPositionOnMap(playerLocation);

        minimapContent.anchoredPosition = new Vector2(-offset.x, -offset.y) * mapScaling;
    }
}