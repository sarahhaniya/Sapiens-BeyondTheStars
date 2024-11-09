using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    [SerializeField] private int keyCollected;
    // Start is called before the first frame update
    void Start()
    {
        keyCollected = 0;
        PlayerPrefs.SetInt("waterBottles", keyCollected);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetKeys()
    {
        return keyCollected;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bottle"))
        {
            Destroy(collision.gameObject);

            keyCollected++;
            PlayerPrefs.SetInt("waterBottles", keyCollected);
        }
    }
}
