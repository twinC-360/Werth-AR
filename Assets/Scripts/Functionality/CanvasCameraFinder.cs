using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class CanvasCameraFinder : MonoBehaviour
{
    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
    }
}