using UnityEngine;

public class ZoomPanController : MonoBehaviour
{
    [Header("Map Holder")]
    [SerializeField] private RectTransform mapMover;
    [SerializeField] private RectTransform mapScaler;

    [Header("Paning")]
    [SerializeField] private float limitX;
    [SerializeField] private float limitY;

    [Header("Scaling")]
    [SerializeField] public float minimumSize;
    [SerializeField] public float maximumSize;

    private void OnDisable()
    {
        ResetMap();
    }

    private void LateUpdate()
    {
        //Scale
        float clampedScale = Mathf.Clamp(mapScaler.localScale.x, minimumSize, maximumSize);
        mapScaler.localScale = new Vector3(clampedScale, clampedScale, clampedScale);

        //Position
        float clampedXPosition = Mathf.Clamp(mapMover.anchoredPosition.x, -limitX, limitX);
        float clampedYPosition = Mathf.Clamp(mapMover.anchoredPosition.y, -limitY, limitY);
        mapMover.anchoredPosition = new Vector3(clampedXPosition, clampedYPosition, 0);
    }

    private void ResetMap()
    {
        mapScaler.localScale = Vector3.one;
        mapMover.anchoredPosition = Vector3.zero;
    }
}
