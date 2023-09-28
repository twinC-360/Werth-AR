using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject fullMap;
    [SerializeField] private GameObject miniMap;

    private void Awake()
    {
        ActivateFullMap(false);
    }

    public void ActivateFullMap(bool status)
    {
        fullMap.SetActive(status);
        miniMap.SetActive(!status);
    }
}