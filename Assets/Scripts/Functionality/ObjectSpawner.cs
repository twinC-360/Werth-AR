using UnityEngine;
using UnityEngine.XR.ARFoundation;


public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    private GameObject spawnedObject;

    private void OnEnable()
    {
        RaycastManager.OnARPlaneHit += OnARPlaneHit;
    }
    private void OnDisable()
    {
        RaycastManager.OnARPlaneHit -= OnARPlaneHit;
    }

    public void OnARPlaneHit(Vector3 position, Quaternion rotation)
    {
        if (spawnedObject != null) return;
        spawnedObject = Instantiate(objectToSpawn, position, rotation);
        spawnedObject.AddComponent<ARAnchor>();
    }
}