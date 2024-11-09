using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Respawn : MonoBehaviour
{
    private Transform currentCheckpoint;
    private Level3Health playyerHealth;

    private void Awake()
    {
        playyerHealth = GetComponent<Level3Health>();

    }

    public void Respawning() {

        transform.position = currentCheckpoint.position;
        playyerHealth.Respawn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }


}
