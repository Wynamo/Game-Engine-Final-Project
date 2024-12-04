using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ScreenBrightnessController : MonoBehaviour
{
    public Slider brightnessSlider; // Reference to the UI Slider
    public Volume postProcessingVolume; // Reference to the Post-Processing Volume
    public float minExposure = -2.0f; // Minimum brightness (darker screen)
    public float maxExposure = 2.0f;  // Maximum brightness (brighter screen)

    private ColorAdjustments colorAdjustments; // Reference to the Color Grading settings

    private void Start()
    {
        if (brightnessSlider == null || postProcessingVolume == null)
        {
            Debug.LogError("Brightness Slider or Post-Processing Volume is not assigned!");
            return;
        }

        // Get the Color Adjustments from the Post-Processing Volume
        if (postProcessingVolume.profile.TryGet(out colorAdjustments))
        {
            // Initialize slider values
            brightnessSlider.minValue = minExposure;
            brightnessSlider.maxValue = maxExposure;
            brightnessSlider.value = colorAdjustments.postExposure.value;

            // Add listener for slider value changes
            brightnessSlider.onValueChanged.AddListener(UpdateBrightness);
        }
        else
        {
            Debug.LogError("Color Adjustments effect is not added to the Post-Processing Volume!");
        }
    }

    // Update the brightness based on slider value
    private void UpdateBrightness(float value)
    {
        if (colorAdjustments != null)
        {
            colorAdjustments.postExposure.value = value;
        }
    }
}

