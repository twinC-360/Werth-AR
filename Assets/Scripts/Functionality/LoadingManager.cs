using UnityEngine.SceneManagement;

public class LoadingManager
{
    //Scene names
    public static string PlaceSelection = "PlaceSelection"; // CD: This seems to be some kind of "Enum".
    public static string Werth = "WerthAR";

    //Selected place
    public static int selectedPlace;
    public static bool useMockLocationData;
    public static bool openPlaceSelection;

    public static void LoadScene(string sceneName, int placeIndex, bool openPlaceSelectionScreen)
    {
        selectedPlace = placeIndex;
        openPlaceSelection = openPlaceSelectionScreen;
        SceneManager.LoadScene(sceneName);
    }
}