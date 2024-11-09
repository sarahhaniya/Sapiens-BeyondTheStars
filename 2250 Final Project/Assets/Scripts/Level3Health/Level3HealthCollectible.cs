using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Level3Health>().AddHealth(healthValue);
        }
    }
}
