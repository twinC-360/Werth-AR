using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Vector3 touchPosition;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
                RaycastManager.Raycast(touchPosition);
        }
    }
}