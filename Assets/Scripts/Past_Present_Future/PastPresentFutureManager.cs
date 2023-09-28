using ARLocation;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PastPresentFutureManager : MonoBehaviour
{
    public static Action<int> OnTimeChanged { get; set; }

    // Sprites for GPS On/Off
    public Sprite GPSOnSprite;
    public Sprite GPSOffSprite;
    // UI Elements
    public Image GPSImage;
    public float pulseDuration = 7.0f;

    public void Start()
    {
        StartCoroutine(PulsateRoutine());
    }

    // Make GPS image pulsate by changing it's alphachannel with a bouncing curve.
    public IEnumerator PulsateRoutine()
    {
        var startTime = Time.time;
        Color spriteColor = GPSImage.color;
        float alpha = 0;
        while(Time.time - startTime < pulseDuration)
        {
            alpha = (float) Math.Abs(Math.Sin((Time.time - startTime) * MathF.PI));
            GPSImage.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha) ;
            yield return null;
        }
        GPSImage.color = spriteColor;
    }

    //0==Present 1==Past 2==Future
    public void TimeChange(int index)
    {
        OnTimeChanged?.Invoke(index);

        if(index == 0) // Present
        {
            Debug.Log("Present mode - Restart Compass + GPS");
            ARLocationProvider.Instance.Provider.Resume();
            ARLocationOrientation.Instance.Resume();
            if (!LoadingManager.useMockLocationData && ARLocationProvider.Instance.Provider.HasStarted)
                GPSImage.sprite = GPSOnSprite;
        }
        else
        {
            Debug.Log("Past or Future mode - Pause Compass + GPS");
            ARLocationProvider.Instance.Provider.Pause();
            ARLocationOrientation.Instance.Pause();
            GPSImage.sprite = GPSOffSprite;
        }
    }
}