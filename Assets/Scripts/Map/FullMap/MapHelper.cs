using ARLocation;
using UnityEngine;

public class MapHelper : MonoBehaviour
{
    [SerializeField] private LocationData referencePointOne, referencePointTwo;
    [SerializeField] private Transform mapTransform;

    private Vector2 referencePointOneOnMap, referencePointTwoOnMap;
    public RectTransform referencePointOneRT, referencePointTwoRT;
    public GameObject MarkerPrefab;

    private float scale, angle;

    public float MapRotation { get => angle; }

    private void Awake()
    {
        referencePointOneOnMap = Flip(referencePointOneRT.anchoredPosition);
        referencePointTwoOnMap = Flip(referencePointTwoRT.anchoredPosition);

        // Calculate scale and orientation (around Refpoint1) of our map
        double geoDistance = Location.HorizontalDistance(referencePointTwo.Location, referencePointOne.Location);
        Debug.Log("Distance between reference points: " + geoDistance);
        var geoVector = Location.VectorFromToEcefEnu(referencePointOne.Location, referencePointTwo.Location); // From One to Two
        Debug.Log("Geovector (ENU): " + geoVector); // Result seems to be NEU. not ENU...!
        var mapVector = referencePointTwoOnMap - referencePointOneOnMap; // From One to Two
        Debug.Log("Map vector (px): " + mapVector);
        angle = Vector2.SignedAngle(geoVector.toVector2(), mapVector);
        Debug.Log("Our map is rotated by " + angle + "degrees");

        var mapDistance = referencePointTwoOnMap - referencePointOneOnMap;
        scale = mapDistance.magnitude / (float)geoDistance;
        Debug.Log("Our scale is " + scale + " pixels per meter");
    }

    private void Start()
    {
        //PutMarkerOnMap(referencePointOne.Location, "Ref 1");
        //PutMarkerOnMap(referencePointTwo.Location, "Ref 2");
    }

    private Vector2 Flip(Vector2 vector)
    {
        return new Vector2(vector.x, -vector.y);
    }

    public Vector2 GetPositionOnMap(Location location)
    {
        var geoVectorToNewPoint = Location.VectorFromToEcefEnu(referencePointOne.Location, location);
        var offset = (Vector2)(Quaternion.Euler(0, 0, angle) * (geoVectorToNewPoint.toVector2()) * scale);
        return Flip(referencePointOneOnMap + new Vector2(offset.x, offset.y));
    }

    //public Vector2 GetMinimapPosition(Vector2 referencePoint, float inputScale, Location referenceLocation, Location playerLocation) // TODO: This works? I have my doubts!
    //{
    //    var geoVectorToNewPoint = Location.VectorFromToEcefEnu(referenceLocation, playerLocation);
    //    var offset = (Vector2)(Quaternion.Euler(0, 0, angle) * (geoVectorToNewPoint.toVector2()) * inputScale);
    //    return referencePoint + new Vector2(offset.x, offset.y);
    //}

    // Place marker on map based on reference points
    public void PutMarkerOnMap(InterestPoint_ScriptableObject interestPoint)
    {
        var marker = Instantiate(MarkerPrefab, mapTransform);
        var rectTrans = marker.GetComponent<RectTransform>();

        rectTrans.anchoredPosition = GetPositionOnMap(interestPoint.locationData.Location);

        marker.GetComponent<MapMarker>()?.UpdateMarker(interestPoint);
    }

    public void PutMarkerOnMap(Location Location)
    {
        var marker = Instantiate(MarkerPrefab, mapTransform);
        var rectTrans = marker.GetComponent<RectTransform>();

        rectTrans.anchoredPosition = GetPositionOnMap(Location);

//        marker.GetComponent<MapMarker>()?.UpdateMarker(interestPoint);
    }

    //Used for player icon on full map
    public void PlacePlayerRectAtLocation(RectTransform rect, Location location)
    {
        rect.anchoredPosition = GetPositionOnMap(location);
    }
}