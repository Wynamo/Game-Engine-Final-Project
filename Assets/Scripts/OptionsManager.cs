using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [System.Serializable]
    public class SliderSetting
    {
        public Slider slider; // The UI slider for the setting
        public float defaultValue; // The default value of the slider
    }

    public SliderSetting[] settings; // Array of settings with sliders and default values

    private void Start()
    {
        // Initialize sliders with their default values
        foreach (var setting in settings)
        {
            if (setting.slider != null)
            {
                setting.slider.value = setting.defaultValue;
            }
        }
    }

    // Restore all sliders to their default values
    public void RestoreDefaults()
    {
        foreach (var setting in settings)
        {
            if (setting.slider != null)
            {
                setting.slider.value = setting.defaultValue;
            }
        }

        Debug.Log("All settings restored to defaults.");
    }
}

