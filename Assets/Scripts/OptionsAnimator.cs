using UnityEngine;
using UnityEngine.UI;

public class CameraAnimatorController : MonoBehaviour
{
    public Animator cameraAnimator;
    public Button[] buttons; // Array of buttons
    public string[] animationNames; // Corresponding animation names

    private void Start()
    {
        if (cameraAnimator == null)
        {
            Debug.LogError("Animator is not assigned!");
            return;
        }

        if (buttons.Length != animationNames.Length)
        {
            Debug.LogError("Mismatch between buttons and animation names!");
            return;
        }

        // Assign button listeners dynamically
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Capture index for the listener
            buttons[i].onClick.AddListener(() => PlayAnimation(animationNames[index]));
        }
    }

    public void PlayAnimation(string animationName)
    {
        if (cameraAnimator != null)
        {
            cameraAnimator.Play(animationName);
        }
    }
}
