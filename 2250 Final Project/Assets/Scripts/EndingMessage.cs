using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndingMessage : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private TMP_Text text;



    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Fruits: " + player.GetComponent<PlayerMovement>().fruitCollected.ToString()+"\n"
            +"Water bottles: " + PlayerPrefs.GetInt("waterBottles")+"\n"
            +"Time: " + PlayerPrefs.GetString("finalTime");
    }
}
