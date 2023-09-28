using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject selectionMenu;

    private void Awake()
    {
        //Open selection menu if loading manager option enabled
        GameObject initialMenu = LoadingManager.openPlaceSelection ? selectionMenu : startMenu;
        ActivateMenu(initialMenu);
    }

    public void ActivateMenu(GameObject menu)
    {
        startMenu.SetActive(false);
        selectionMenu.SetActive(false);

        menu.SetActive(true);
    }
}