using UnityEngine;
using UnityEngine.UI;

public class MuteButtonController : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource to mute/unmute
    public Button button; // The button to toggle mute on click

    private void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned!");
            return;
        }

        if (button == null)
        {
            Debug.LogError("Button is not assigned!");
            return;
        }

        // Add the toggle mute listener to the button's OnClick event
        button.onClick.AddListener(ToggleMute);
    }

    // Toggle mute state of the AudioSource
    private void ToggleMute()
    {
        if (audioSource != null)
        {
            audioSource.mute = !audioSource.mute; // Toggle mute state
        }
    }
}

