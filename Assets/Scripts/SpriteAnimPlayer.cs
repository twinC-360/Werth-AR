using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimPlayer : MonoBehaviour
{
    // Take a list of sprite and change the image component of the game object
    // every x seconds
    public List<Sprite> sprites;
    public float speed;

    private UnityEngine.UI.Image image;
    private int currentIndex = 0;
    private float elapsedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 1.0f / speed)
        {
            elapsedTime = 0.0f;
            currentIndex++;
            if (currentIndex >= sprites.Count)
                currentIndex = 0;
            image.sprite = sprites[currentIndex];
        }
    }
}
