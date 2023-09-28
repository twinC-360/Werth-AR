using ARLocation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassOffsetSlider : MonoBehaviour
{
    public Slider slider;
    public TMPro.TextMeshProUGUI calibratingText;
    public Button button;
    public Toggle compassToggle;

    public void Start()
    {
        InvokeRepeating(nameof(UpdateDisplay), 0f, 0.5f);
    }

    public void OnSliderValueChanged(float value)
    {
        ARLocation.ARLocationOrientation.Instance.TrueNorthOffset = value;
        //ARLocation.ARLocationProvider.Instance.ForceLocationUpdate();
    }

    public void OnResetButton()
    {
        slider.value = 0;
        ARLocation.ARLocationOrientation.Instance.TrueNorthOffset = 0;
        ARLocation.ARLocationOrientation.Instance.ResetUpdateCounter();
        InvokeRepeating(nameof(UpdateDisplay), 0f, 0.5f);
    }

    public void UpdateDisplay()
    {
        if(ARLocation.ARLocationOrientation.Instance.isCalibrating())
        {
            calibratingText.gameObject.SetActive(true);
            button.gameObject.SetActive(false);
            slider.gameObject.SetActive(false);
            compassToggle.isOn = true;
        }
        else
        {
            calibratingText.gameObject.SetActive(false);
            button.gameObject.SetActive(true);
            slider.gameObject.SetActive(true);
            CancelInvoke();
            compassToggle.isOn = false;
        }
    }

    public void SetTrackingToMockLocation()
    {
        if (LoadingManager.useMockLocationData)
        {

            var playerLocation = ARLocationManager.Instance.GetLocationForWorldPosition(Camera.main.transform.position);
            ((UnityLocationProvider)ARLocationProvider.Instance.Provider).SetMockLocation(playerLocation);
            ARLocationManager.Instance.ResetARSession();
            ARLocationProvider.Instance.Provider.ForceLocationUpdate();
        }
    }

    public void OnGPSToggleChanged(bool useGPS)
    {
        if (useGPS)
            ARLocationProvider.Instance.Provider.Resume();
        else
            ARLocationProvider.Instance.Provider.Pause();
    }

    public void OnCompassToggleChanged(bool useCompass)
    {
        if (useCompass)
            ARLocationOrientation.Instance.MaxNumberOfUpdates = 0; // Endless
        else
            ARLocationOrientation.Instance.MaxNumberOfUpdates = 1;
    }


}
