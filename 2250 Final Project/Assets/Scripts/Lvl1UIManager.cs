using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lvl1UIManager : MonoBehaviour
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
        text.text = " Fruits Collected: " + player.GetComponent<PlayerMovement>().fruitCollected.ToString();
    }
}
