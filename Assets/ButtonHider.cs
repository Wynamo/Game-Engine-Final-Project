using UnityEngine;
using UnityEngine.UI;

public class HideAndDisableController : MonoBehaviour
{
    public GameObject targetObject; // The target object you want to hide and make uninteractable
    public Button triggerButton;    // Button that triggers the hide and disable function

    private Renderer targetRenderer; // Renderer to hide the object
    private Collider targetCollider; // Collider to make the object uninteractable

    private void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target GameObject is not assigned!");
            return;
        }

        // Get components on the target object
        targetRenderer = targetObject.GetComponent<Renderer>();
        targetCollider = targetObject.GetComponent<Collider>();

        if (triggerButton != null)
        {
            triggerButton.onClick.AddListener(HideAndDisable); // Add the HideAndDisable function to the button's OnClick event
        }
        else
        {
            Debug.LogError("Trigger button is not assigned!");
        }
    }

    // Hide the target object and make it uninteractable
    public void HideAndDisable()
    {
        if (targetRenderer != null)
        {
            targetRenderer.enabled = false; // Hide the object by disabling its renderer
        }

        if (targetCollider != null)
        {
            targetCollider.enabled = false; // Disable the collider to make the object uninteractable
        }

        // If the object has a button, you can also make it uninteractable like this:
        Button targetButton = targetObject.GetComponent<Button>();
        if (targetButton != null)
        {
            targetButton.interactable = false; // Make the button uninteractable
        }
    }

    // Show the target object and make it interactable again (optional for resetting)
    public void ShowAndEnable()
    {
        if (targetRenderer != null)
        {
            targetRenderer.enabled = true; // Show the object by enabling its renderer
        }

        if (targetCollider != null)
        {
            targetCollider.enabled = true; // Enable the collider to make the object interactable again
        }

        // If the object has a button, you can also make it interactable like this:
        Button targetButton = targetObject.GetComponent<Button>();
        if (targetButton != null)
        {
            targetButton.interactable = true; // Make the button interactable again
        }
    }
}
