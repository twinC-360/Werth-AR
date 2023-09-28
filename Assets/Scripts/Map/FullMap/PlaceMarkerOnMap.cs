using UnityEngine;

public class PlaceMarkerOnMap : MonoBehaviour
{
    [SerializeField] private InterestPoint_ScriptableObject[] locations;
    private MapHelper mapHelper;

    private void Awake()
    {
        mapHelper = FindObjectOfType<MapHelper>();
    }
    private void Start()
    {
        foreach (var location in locations)
            mapHelper.PutMarkerOnMap(location);
    }
}