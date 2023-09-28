using ARLocation;
using UnityEngine;

// Put this on your Compass UI element
public class RotateCompass : MonoBehaviour
{
    private ARLocationProvider arLocationProvider;
    private RectTransform rectTransform;
    [SerializeField] Transform ARLocationRoot;
    [SerializeField] Transform ARCamera;

    private void Awake()
    {
        arLocationProvider = FindObjectOfType<ARLocationProvider>();
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        //rectTransform.rotation = Quaternion.Euler(0, 0,
        //    (float)arLocationProvider.CurrentHeading.magneticHeading);

        // Roatate compass according to the difference between camera an ARLocationRoot
        rectTransform.rotation = Quaternion.Euler(0, 0,
            ARCamera.rotation.eulerAngles.y - ARLocationRoot.rotation.eulerAngles.y);
    }
}