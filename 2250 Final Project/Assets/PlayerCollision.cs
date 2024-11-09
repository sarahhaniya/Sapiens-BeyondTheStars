using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Raindrop")
        {
            PlayerDeath1.isPlayerDead = true;
            gameObject.SetActive(false);
        }
    }
}
