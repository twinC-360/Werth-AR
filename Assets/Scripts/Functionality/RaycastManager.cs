using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using ARLocation;

public class RaycastManager : MonoBehaviour
{
    public static Action<Vector3, Quaternion> OnARPlaneHit;
    public static Action OnObjectSpawned;
    private static ARRaycastManager arRaycastManager;

    //Hotspot layer
    [SerializeField] private LayerMask hotspotLayer;
    private static LayerMask hotspotStaticLayer;

    //Hotspot layer
    [SerializeField] private TrackableType trackableType;
    public static TrackableType trackableStaticType { get; private set; }

    private void Awake()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        hotspotStaticLayer = hotspotLayer;
        trackableStaticType = trackableType;
    }

    public static void Raycast(Vector3 position)
    {
        //Raycast, if butterfly make it flap, if not spawn one
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hitObject;

        if (Physics.Raycast(ray, out hitObject, Mathf.Infinity, hotspotStaticLayer))
        {
            if (hitObject.transform.TryGetComponent(out HotspotObject hotspot))
                hotspot.ShowInfo();
        }
        else
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            arRaycastManager.Raycast(position, hits, trackableStaticType);

            if (hits.Count > 0)
            {
                var pose = hits[0].pose;

                float compassRotation = (float)ARLocationProvider.Instance.CurrentHeading.heading;
                Vector3 finalEulerRotation = new Vector3(pose.rotation.eulerAngles.x, pose.rotation.eulerAngles.y + compassRotation,
                    pose.rotation.eulerAngles.z);
                Quaternion finalRotation = Quaternion.Euler(finalEulerRotation);

                OnARPlaneHit?.Invoke(pose.position, finalRotation);
                OnObjectSpawned?.Invoke();
            }
        }
    }
}