using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DelayedActionController : MonoBehaviour
{
    /// <summary>
    /// Invokes an action after a specified delay.
    /// </summary>
    /// <param name="delay">Time in seconds to wait before invoking the action.</param>
    /// <param name="action">The UnityAction to invoke after the delay.</param>
    public void ExecuteAfterDelay(float delay, UnityAction action)
    {
        StartCoroutine(ExecuteAfterDelayCoroutine(delay, action));
    }

    private IEnumerator ExecuteAfterDelayCoroutine(float delay, UnityAction action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
}

