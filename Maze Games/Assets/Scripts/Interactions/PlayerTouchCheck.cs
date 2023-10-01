using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchCheck : MonoBehaviour
{
    private bool isPlayerInRange = false;
    [SerializeField] private GameObject Light;
    [SerializeField] private GameObject Fire;

    private ParticleSystem fireParticleSystem;
    // Reference to the Particle System component

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");

        // Get the Particle System component from the fireObject
        fireParticleSystem = Fire.GetComponent<ParticleSystem>();
    }


    void Update()
    {
        // Check if the player is in range and pressed the "E" key
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interaction detected");

            // Toggle the state of the Light
            ToggleGameObjectState(Light);


            // If the fireObject has a Particle System component
            if (fireParticleSystem != null)
            {
                // Toggle the emission of the Particle System
                ToggleParticleSystemEmission(fireParticleSystem);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider belongs to the player
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting collider belongs to the player
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }


    // Helper method to toggle the active state of a GameObject
    private void ToggleGameObjectState(GameObject obj)
    {
        if (obj != null)
        {
            obj.SetActive(!obj.activeSelf); // Toggle the active state
        }
    }



    // Helper method to toggle the emission of a Particle System
    private void ToggleParticleSystemEmission(ParticleSystem particleSystem)
    {
        if (particleSystem.isPlaying)
        {
            particleSystem.Stop(); // Stop emitting new particles
        }
        else
        {
            particleSystem.Play(); // Resume emitting particles if stopped
        }
    }

}
