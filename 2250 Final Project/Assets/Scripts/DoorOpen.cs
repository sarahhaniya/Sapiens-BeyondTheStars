using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour
{
    public int switchOrder;
    private SpriteRenderer spriteRenderer;
    public Sprite doorOne;
    public Sprite doorTwo;
    public Sprite doorThree;
    public Sprite doorOpen;
    public BoxCollider2D boxCollider;
    public GameObject player;

    // Start is called before the first frame update
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        switchOrder = 0;
        boxCollider.enabled = false;
        player = GameObject.Find("Player");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (switchOrder == 3)
        {
            spriteRenderer.sprite = doorOpen;
            boxCollider.enabled = false;
            new WaitForSeconds(1);
           
            player.GetComponent<PlayerMovement>().saveInfo();

            SceneManager.LoadScene(sceneName: "FallingObject");
        }
    }

    public void One()
    {
        player.GetComponent<PlayerMovement>().switchOrder = 1;
        spriteRenderer.sprite = doorOne;
    }
    public void Two()
    {
        player.GetComponent<PlayerMovement>().switchOrder = 2;
        spriteRenderer.sprite = doorTwo;
    }
    public void Three()
    {
        player.GetComponent<PlayerMovement>().switchOrder = 3;
        spriteRenderer.sprite = doorThree;
        boxCollider.enabled = true;
    }
}
