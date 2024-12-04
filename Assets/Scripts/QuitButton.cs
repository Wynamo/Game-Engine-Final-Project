using UnityEngine;

public class QuitGameButton : MonoBehaviour
{
    // This function is called when the button is clicked
    public void QuitGame()
    {
#if UNITY_EDITOR
        // If running in the Unity Editor, stop play mode
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}