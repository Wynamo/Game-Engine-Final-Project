using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAnimatorController : MonoBehaviour
{
    public Animator buttonAnimator; // Animator for button animations
    public Button button; // Button component
    public string hoverTrigger = "Hover"; // Trigger for hover animation
    public string clickTrigger = "Click"; // Trigger for click animation
    public string idleStateName = "Idle"; // Name of the idle animation state

    private bool isHovering = false; // Tracks if the cursor is over the button

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

        // Add hover and exit listeners
        AddHoverListeners();

        // Add click listener
        button.onClick.AddListener(() => PlayClickAnimation());
    }

    // Play hover animation
    private void PlayHoverAnimation()
    {
        if (buttonAnimator != null && !isHovering)
        {
            isHovering = true;
            buttonAnimator.SetTrigger(hoverTrigger);
        }
    }

    // Stop hover animation (return to idle state)
    private void StopHoverAnimation()
    {
        if (buttonAnimator != null && isHovering)
        {
            isHovering = false;
            buttonAnimator.Play(idleStateName);
        }
    }

    // Play click animation
    private void PlayClickAnimation()
    {
        if (buttonAnimator != null)
        {
            buttonAnimator.SetTrigger(clickTrigger);
        }
        StopHoverAnimation(); // Stop hovering when clicked
    }

    // Add hover listeners using EventTrigger
    private void AddHoverListeners()
    {
        EventTrigger eventTrigger = button.gameObject.AddComponent<EventTrigger>();

        // PointerEnter (hover start)
        EventTrigger.Entry pointerEnterEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerEnter
        };
        pointerEnterEntry.callback.AddListener((data) => PlayHoverAnimation());
        eventTrigger.triggers.Add(pointerEnterEntry);

        // PointerExit (hover stop)
        EventTrigger.Entry pointerExitEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerExit
        };
        pointerExitEntry.callback.AddListener((data) => StopHoverAnimation());
        eventTrigger.triggers.Add(pointerExitEntry);
    }
}