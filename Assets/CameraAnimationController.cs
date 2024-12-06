using UnityEngine;
using UnityEngine.UI;

public class CameraAnimationController : MonoBehaviour
{
    public Animator cameraAnimator; // Animator for the camera
    public Button[] buttons; // Array of buttons
    public string[] animationTriggers; // Animation triggers corresponding to each button

    private void Start()
    {
        if (cameraAnimator == null)
        {
            Debug.LogError("Camera Animator is not assigned!");
            return;
        }

        if (buttons.Length != animationTriggers.Length)
        {
            Debug.LogError("Mismatch between buttons and animation triggers!");
            return;
        }

        // Assign listeners to buttons
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Capture the current index for the closure
            buttons[i].onClick.AddListener(() => PlayCameraAnimation(animationTriggers[index]));
        }
    }

    private void PlayCameraAnimation(string triggerName)
    {
        if (cameraAnimator != null && !string.IsNullOrEmpty(triggerName))
        {
            Debug.Log("Playing camera animation: " + triggerName);
            cameraAnimator.SetTrigger(triggerName);
        }
    }
}

