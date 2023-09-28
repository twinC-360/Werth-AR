using System;
using System.Linq;
using UnityEngine;
using ARLocation;

public class CitySpawner : PlaceAtLocations
{
    [SerializeField] private GameObject[] cityParts;
    [SerializeField] private LocationData[] anchorLocations;

    private void Start()
    {
        SpawnCityPart();
    }

    private void SpawnCityPart()
    {
//        Location location = InitialLocation.currentInitialLocation;
//        GameObject cityPart;

        //If GPS mode choose the closest city part
        //if (!LoadingManager.useMockLocationData)
        //{
        //    //Find closest point
        //    double[] distancesToStartingPoints = { DistanceFromCurrentLocation(anchorLocations[0].Location),
        //        DistanceFromCurrentLocation(anchorLocations[1].Location),
        //        DistanceFromCurrentLocation(anchorLocations[2].Location)};

        //    int minIndex = Array.IndexOf(distancesToStartingPoints, distancesToStartingPoints.Min());

        //    cityPart = cityParts[minIndex];
        //    var anchorLocation = anchorLocations[minIndex].Location;
        ////}
        ////Otherwise go with the one picked in the menu
        //else
        //{
        //    cityPart = cityParts[LoadingManager.selectedPlace];
        //}
//        Debug.Log("Placing City part: " + cityPart.name + " at position" + anchorLocations[minIndex].name);
//        var instance = PlaceAtLocation.CreatePlacedInstance(cityPart, anchorLocation, PlacementOptions, DebugMode);
        var instance = PlaceAtLocation.CreatePlacedInstance(cityParts[0], anchorLocations[0].Location, PlacementOptions, DebugMode);
        locations.Add(anchorLocations[0].Location);
        instances.Add(instance);

        instance = PlaceAtLocation.CreatePlacedInstance(cityParts[1], anchorLocations[1].Location, PlacementOptions, DebugMode);
        locations.Add(anchorLocations[1].Location);
        instances.Add(instance);

        instance = PlaceAtLocation.CreatePlacedInstance(cityParts[2], anchorLocations[2].Location, PlacementOptions, DebugMode);
        locations.Add(anchorLocations[2].Location);
        instances.Add(instance);



    }

    private double DistanceFromCurrentLocation(Location location)
    {
        return Location.DistanceWithAltitude(ARLocationProvider.Instance.CurrentLocation.ToLocation(), location);
    }
}