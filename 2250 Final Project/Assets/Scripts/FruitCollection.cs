using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollection : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.GetComponent<PlayerMovement>().fruitCollected += 1;
        Destroy(gameObject);
    }
}
