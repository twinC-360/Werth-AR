using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    public void GoBackToMenu()
    {
        LoadingManager.useMockLocationData = false;
        LoadingManager.LoadScene(LoadingManager.PlaceSelection, 0, true);
    }
}