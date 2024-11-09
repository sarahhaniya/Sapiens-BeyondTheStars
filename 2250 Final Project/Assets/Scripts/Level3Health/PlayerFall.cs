using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigidbody;  
    [SerializeField] private float FallingThreshold;
    public bool Falling = false;

    private Level3Respawn respawn;

    private void Awake()
    {
        respawn = GetComponent<Level3Respawn>();

    }
    void Update()
    {
        if (myRigidbody.transform.position.y < FallingThreshold)
        {
            Falling = true;
        }
        else
        {
            Falling = false;
        }

        if (Falling)
        {
            respawn.Respawning();
        }
    }

}
