using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float healthIncreaseAmount = 0.1f; // Amount to increase the health bar

    private HealthBar healthBar; // Reference to the health bar object

    [System.Obsolete]
    private void Start()
    {
        // Find the HealthBar object in the scene
        healthBar = FindObjectOfType<HealthBar>();
    }
    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the object collides with the player
            Debug.Log("Player collected the object!");

            // Destroy the object when the player touches it
            Destroy(gameObject);

            if (healthBar != null)
            {
                healthBar.IncreaseHealth(healthIncreaseAmount);
            }
        }
        
    }
}

