using UnityEngine;

public class AutomaticEmissionIntensity : MonoBehaviour
{
    public float minIntensity = 0.0f;       // Minimum emission intensity during the active phase
    public float maxIntensity = 1.0f;      // Maximum emission intensity during the active phase
    public float changeSpeed = 1.0f;       // Speed at which the intensity oscillates
    public float idleIntensity = 0.0f;     // Intensity to use between loops

    public float activationTime = 2.0f;    // Time before the emission starts (in seconds)
    public float duration = 5.0f;          // How long the emission effect lasts (in seconds)
    public float loopDelay = 2.0f;         // Delay after the emission turns off before it starts again

    private Material material;             // The material of the object
    private Color initialEmissionColor;    // The initial emission color

    private float timer = 0.0f;            // Timer to control the activation
    private bool isActive = false;         // Flag to check if emission change is active

    void Start()
    {
        // Get the material of the object (ensure it has an Emission property)
        material = GetComponent<Renderer>().material;

        // Cache the initial emission color to modify its intensity
        if (material.HasProperty("_EmissionColor"))
        {
            initialEmissionColor = material.GetColor("_EmissionColor");
        }
        else
        {
            Debug.LogWarning("Material does not have an emission property.");
        }

        // Set the initial emission intensity to the idle intensity
        SetEmissionIntensity(idleIntensity);
    }

    void Update()
    {
        // Update the timer based on the elapsed time since the start of the game
        timer += Time.deltaTime;

        // Check if the emission effect is within the active phase (start after activationTime and for duration seconds)
        if (timer >= activationTime && timer < activationTime + duration)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }

        // If the effect is active, modify the emission intensity
        if (isActive && material.HasProperty("_EmissionColor"))
        {
            // Calculate the normalized time within the emission period
            float elapsedActiveTime = timer - activationTime;

            // Calculate the oscillation phase based on the change speed
            float oscillation = Mathf.PingPong(elapsedActiveTime * changeSpeed, 1.0f);

            // Oscillate between minIntensity and maxIntensity
            float currentIntensity = Mathf.Lerp(minIntensity, maxIntensity, oscillation);

            SetEmissionIntensity(currentIntensity);
        }
        else
        {
            // When inactive, set the emission intensity to the idle intensity
            SetEmissionIntensity(idleIntensity);
        }

        // If the timer exceeds the duration + loop delay, reset to start the next cycle
        if (timer >= activationTime + duration + loopDelay)
        {
            timer = 0.0f; // Reset the timer for the next loop
        }
    }

    private void SetEmissionIntensity(float intensity)
    {
        // Apply the emission color with the calculated intensity multiplier
        Color emissionColor = initialEmissionColor * intensity;

        // Apply the emission color to the material
        material.SetColor("_EmissionColor", emissionColor);

        // Update the lighting in the scene
        DynamicGI.UpdateEnvironment();
    }
}
