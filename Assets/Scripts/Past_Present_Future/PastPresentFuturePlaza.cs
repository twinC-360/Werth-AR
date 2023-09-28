using UnityEngine;

public class PastPresentFuturePlaza : MonoBehaviour
{
    [SerializeField] private GameObject[] pastPresentFuturePlazas;

    private void OnEnable()
    {
        PastPresentFutureManager.OnTimeChanged += OnTimeChanged;
    }
    private void OnDisable()
    {
        PastPresentFutureManager.OnTimeChanged -= OnTimeChanged;
    }
    private void Start()
    {
        OnTimeChanged(0);
    }

    private void OnTimeChanged(int index)
    {
        // Deaactive all
        foreach(var plaza in pastPresentFuturePlazas)
            plaza.SetActive(false);

        // Reactive ours
        pastPresentFuturePlazas[index].SetActive(true);
        // Why? Because this way we can reuse an object for more than one time mode without getting deactived again.
    }
}