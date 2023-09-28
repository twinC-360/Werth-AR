using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PastPresentFutureButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Sprite activeSprite;
    [SerializeField] private Sprite inactiveSprite;

    private void OnEnable()
    {
        PastPresentFutureManager.OnTimeChanged += OnTimeChanged;
    }
    private void OnDisable()
    {
        PastPresentFutureManager.OnTimeChanged -= OnTimeChanged;
    }

    private void OnTimeChanged(int timeIndex)
    {
        button.image.sprite = timeIndex == transform.GetSiblingIndex() ? activeSprite : inactiveSprite;
    }
}