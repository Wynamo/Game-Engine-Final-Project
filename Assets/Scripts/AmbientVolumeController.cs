using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the UI Slider
    public AudioSource[] audioSources; // Array of AudioSources to control

    private float defaultVolume = 1.0f; // Default volume level (100%)

    private void Start()
    {
        if (volumeSlider == null)
        {
            Debug.LogError("Volume Slider is not assigned!");
            return;
        }

        // Initialize slider value and set listener
        volumeSlider.minValue = 0.0f; // Mute
        volumeSlider.maxValue = 1.0f; // Full volume
        volumeSlider.value = defaultVolume;

        volumeSlider.onValueChanged.AddListener(UpdateVolume);

        // Set all audio sources to the default volume at start
        UpdateVolume(defaultVolume);
    }

    // Updates the volume of all audio sources
    private void UpdateVolume(float value)
    {
        foreach (var audioSource in audioSources)
        {
            if (audioSource != null)
            {
                audioSource.volume = value;
            }
        }
    }

    // Restore the default volume
    public void RestoreDefaultVolume()
    {
        if (volumeSlider != null)
        {
            volumeSlider.value = defaultVolume;
        }
    }
}
