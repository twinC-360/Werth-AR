using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneVisibility : MonoBehaviour
{
    private ARPlaneManager planeManager;

    private void Awake()
    {
        planeManager = FindObjectOfType<ARPlaneManager>();
        SetPlaneVisibility(false);
    }
    private void OnEnable()
    {
        RaycastManager.OnObjectSpawned += OnObjectSpawned;
    }
    private void OnDisable()
    {
        RaycastManager.OnObjectSpawned -= OnObjectSpawned;
    }

    private void OnObjectSpawned()
    {
        SetPlaneVisibility(false);
    }
    private void SetPlaneVisibility(bool status)
    {
        if (status)
        {
            planeManager.requestedDetectionMode = UnityEngine.XR.ARSubsystems.PlaneDetectionMode.Horizontal;
        }
        else
        {
            planeManager.requestedDetectionMode = UnityEngine.XR.ARSubsystems.PlaneDetectionMode.None;
            foreach (ARPlane trackable in planeManager.trackables)
            {
                trackable.gameObject.SetActive(false);
                trackable.enabled = false;
            }
        }
    }
}