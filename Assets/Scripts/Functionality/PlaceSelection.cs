using UnityEngine;

public class PlaceSelection : MonoBehaviour
{
    public void SelectPlace(int placeIndex)
    {
        LoadingManager.LoadScene(LoadingManager.Werth, placeIndex, false);
    }
    public void SetMockLocationStatus(bool status)
    {
        LoadingManager.useMockLocationData = status;
    }
}