using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaindropFalling : MonoBehaviour
{
    float time = 0.1f;
    public GameObject raindrop;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Raindrop", time, time);
    }

    // Update is called once per frame
    void Raindrop()
    {
        Instantiate(raindrop, new Vector3(Random.Range(-100, 100), 10, 0), Quaternion.identity);
    }
}
