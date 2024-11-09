using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lvl2UIManager : MonoBehaviour
{

    [SerializeField] private PlayerCollection playerCollection;
    [SerializeField] private TMP_Text text;



   // Start is called before the first frame update
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       text.text = "Bottles Collected: " + playerCollection.GetKeys().ToString();

    }
}
