using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathLv2 : MonoBehaviour
{

    public Vector2 initialStartingPosition; // Reference to the initial starting point
    private Lvl2Health playerHealth; // Reference to the player's health script

    public Transform respawnPoint;
    private bool hasPassedCheckpoint = false;


    //// Start is called before the first frame update
    void Start()
    {
        // Set the initial starting position at the beginning of the game
        initialStartingPosition = transform.position;

        // Get reference to the player's health script
        playerHealth = GetComponent<Lvl2Health>();
    }

    private void Update()
    {
        if (playerHealth.currentHealth <=0 ) 
        {
            
           Die();

        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.CompareTag("Checkpoint2"))
        //{
        //    hasPassedCheckpoint = true; // Set to true when passing the checkpoint
        //    respawnPoint = other.transform;
        //    other.GetComponent<Collider>().enabled = false;
        //}


        //if (other.gameObject.CompareTag("Checkpoint2"))
        //{
        //    Collider collider = other.GetComponent<Collider>();
        //    if (collider != null)
        //    {
        //        collider.enabled = false;
        //    }
        //    else
        //    {
        //        Debug.LogWarning("Checkpoint1 object doesn't have a Collider component attached.");
        //    }


        if (other.gameObject.CompareTag("Checkpoint2"))
        {
            hasPassedCheckpoint = true; // Set to true when passing the checkpoint
            respawnPoint = other.transform;

            Collider checkpointCollider = other.GetComponent<Collider>();
            if (checkpointCollider != null)
            {
                checkpointCollider.enabled = false; // Disable the Collider to prevent re-triggering
            }
            else
            {
                Debug.LogWarning("Checkpoint2 object doesn't have a Collider component attached.");
            }
        }


        if (other.CompareTag("Water"))
        {
            if (hasPassedCheckpoint) // Only respawn at checkpoint if passed by it
            {
                playerHealth.TakeDamage(1); // Deduct 1 health from player
                Respawn(); // Respawn at checkpoint
            }
            else
            {
                playerHealth.TakeDamage(1); // Deduct 1 health from player
                RespawnAtNearestGround("Ground"); // Respawn at nearest ground
            }
        }



        else if (other.CompareTag("Spikes"))
        {
            playerHealth.TakeDamage(1); // Deduct 1 heart if colliding with spikes

            // If the player still has health remaining, respawn at nearest ground
            if (playerHealth.currentHealth > 0)
            {
                RespawnAtNearestGround("Ground");
            }

            else
            {
                Die(); // Call the Die method if player has no health left
            }


        }
    }
        



    private void ReactivatePlayer()
    {
        gameObject.SetActive(true);
    }


    private void Respawn()
    {

        transform.position = respawnPoint.position;
    }


    private void RespawnAtNearestGround(string Ground)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down, Mathf.Infinity, LayerMask.GetMask("Ground"));

        float closestDistance = Mathf.Infinity;
        Vector2 respawnPosition = initialStartingPosition;

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.CompareTag(Ground)) // Check if the hit ground has the specified tag
            {
                float distance = Vector2.Distance(transform.position, hit.point);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    respawnPosition = hit.point;
                }
            }
        }

        transform.position = respawnPosition + Vector2.up * 0.5f;
    }

    private void Die()
    {

        // Reset hasPassedCheckpoint when the player dies
        hasPassedCheckpoint = false;

        // Deactivate the player GameObject
        gameObject.SetActive(false);

        // Reset player position to the initial starting point
        transform.position = initialStartingPosition;

        // Refill the player's health upon death
        playerHealth.RefillHealth();

        // Reactivate the player GameObject after a short delay
        Invoke("ReactivatePlayer", 1f);


    }

}