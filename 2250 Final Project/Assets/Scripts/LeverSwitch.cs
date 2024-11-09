using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D boxCollider;
    private GameObject door;


    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        door = GameObject.Find("Door");
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        switch (door.GetComponent<DoorOpen>().switchOrder)
        {
            case 0:
                door.GetComponent<DoorOpen>().One();
                door.GetComponent<DoorOpen>().switchOrder = 1;

                boxCollider.enabled = false;
                transform.localScale = new Vector3(-0.5f, 0.5f, 1);
                
            break;

            case 1:
                door.GetComponent<DoorOpen>().Two();
                door.GetComponent<DoorOpen>().switchOrder = 2;

                boxCollider.enabled = false;
                transform.localScale = new Vector3(-0.5f, 0.5f, 1);
            break;

            case 2:
                door.GetComponent<DoorOpen>().Three();
                door.GetComponent<DoorOpen>().switchOrder = 3;

                boxCollider.enabled = false;
                transform.localScale = new Vector3(-0.5f, 0.5f, 1);
            break;
        }
    }
}
