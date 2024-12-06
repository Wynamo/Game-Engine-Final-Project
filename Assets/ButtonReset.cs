using UnityEngine;
using UnityEngine.UI;

public class ButtonResetController : MonoBehaviour
{
    public Animator buttonAnimator; // Animator for button animations
    public Button button; // Button component
    public string idleStateName = "Idle"; // Name of the idle animation state
    public Color defaultColor = Color.white; // Default color of the button (if changed via script)
    public Color defaultHoverColor = Color.white; // Default hover color of the button (if changed)
    public Color defaultClickColor = Color.white; // Default click color of the button (if changed)

    private ColorBlock defaultColorBlock; // Stores default color settings for the button

    private void Start()
    {
        if (buttonAnimator == null)
        {
            Debug.LogError("Button Animator is not assigned!");
            return;
        }

        if (button == null)
        {
            Debug.LogError("Button component is not assigned!");
            return;
        }

        // Save default button color settings
        defaultColorBlock = button.colors;

        // Reset button to default settings at the start
        ResetButtonToDefault();
    }

    // Reset the button to its default state
    public void ResetButtonToDefault()
    {
        // Reset button color
        button.GetComponent<Image>().color = defaultColor;

        // Reset the button interactability
        button.interactable = true;

        // Reset button color block (reset any hover/click colors)
        button.colors = defaultColorBlock;

        // Reset the button animator to idle state
        if (buttonAnimator != null)
        {
            buttonAnimator.Play(idleStateName); // Play idle animation state
        }

        // Reset the button's hover state
        StopHoverAnimation();
    }

    // Stop hover animation (return to idle state)
    private void StopHoverAnimation()
    {
        if (buttonAnimator != null)
        {
            buttonAnimator.Play(idleStateName);
        }
    }

    // This method is called when the button is clicked to reset
    public void OnButtonClickReset()
    {
        ResetButtonToDefault();
    }

    // This method allows one button to reset another button's state
    public void ResetAnotherButton(ButtonResetController buttonToReset)
    {
        buttonToReset.ResetButtonToDefault();
    }
}
