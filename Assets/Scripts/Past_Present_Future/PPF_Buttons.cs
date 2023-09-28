using UnityEngine;

public class PPF_Buttons : MonoBehaviour
{
    [SerializeField] private GameObject buttonHolder;
    [SerializeField] private bool startActive;

    private void Awake()
    {
        SetButtonsVisibility(startActive);
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
        SetButtonsVisibility(true);
    }
    private void SetButtonsVisibility(bool status)
    {
        buttonHolder.SetActive(status);
    }
}