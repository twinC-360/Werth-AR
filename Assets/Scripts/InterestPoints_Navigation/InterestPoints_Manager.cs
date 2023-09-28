using ARLocation;
using UnityEngine;
using System.Collections.Generic;

public class InterestPoints_Manager : PlaceAtLocations
{
    [SerializeField] private List<InterestPoint_ScriptableObject> interestPoints;
    [SerializeField] private GameObject interestPointPrefab;

    private void Start()
    {
        SpawnInterestPoints();
    }
    private void SpawnInterestPoints()
    {
        foreach (var interestPoint in interestPoints)
            AddInterestPoint(interestPoint.locationData.Location, interestPoint);
    }

    private void AddInterestPoint(Location location, InterestPoint_ScriptableObject interestPoint)
    {
        var instance = PlaceAtLocation.CreatePlacedInstance(interestPointPrefab, location, PlacementOptions, DebugMode);

        if (interestPoint != null)
            instance.GetComponent<InterestPoint_Display>().UpdateInterestPoint(interestPoint);

        instance.name = $"{gameObject.name} - {locations.Count}";

        locations.Add(location);
        instances.Add(instance);
    }
}