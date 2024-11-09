using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float curentPosX;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform player;

    public void Update()
    {
        // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(curentPosX, transform.position.y, transform.position.z), ref velocity, speed);
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

}
