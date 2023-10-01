using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchlightController : MonoBehaviour
{
    public float maxIntensity = 1.0f; // Initial intensity of the torchlight
    public float decreaseRate = 0.01f; // Rate at which torchlight decreases
    private Light torchlight;

    private void Start()
    {
        torchlight = GetComponent<Light>();
        torchlight.intensity = maxIntensity;
    }

    private void Update()
    {
        // Decrease torchlight intensity over time
        torchlight.intensity -= decreaseRate * Time.deltaTime;
    }
}
