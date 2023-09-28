using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SlideOutPanel : MonoBehaviour
{
    [SerializeField] private Button slideOutButton;
    [SerializeField] private RectTransform slideOutRect;
    [SerializeField] private Sprite[] buttonSprites;
    [SerializeField] private float xPosition;
    [SerializeField] private float slideTime;

    private bool panelOpened;

    private void Awake()
    {
        //Default parameters
        UpdateButtonImage();
        slideOutRect.DOAnchorPosX(xPosition, 0);
    }

    public void Slide()
    {
        //Disable button
        slideOutButton.interactable = false;

        float targetXPosition = panelOpened ? xPosition : -xPosition;

        //Slide in/out
        slideOutRect.DOAnchorPosX(targetXPosition, slideTime).SetEase(Ease.Linear).OnComplete(() =>
        {
            //Change current status
            panelOpened = !panelOpened;

            //Change button sprite
            UpdateButtonImage();

            //Re-enable button
            slideOutButton.interactable = true;
        });
    }

    private void UpdateButtonImage()
    {
        int spriteIndex = System.Convert.ToInt32(panelOpened);
        slideOutButton.image.sprite = buttonSprites[spriteIndex];
    }
}