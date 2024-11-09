using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen2 : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite doorOpen;
    public GameObject player;
    public float delayBeforeLoad = 1f;
    public bool isOpen = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isOpen)

        {
            Debug.Log("HEY");
            isOpen = true;
            spriteRenderer.sprite = doorOpen; // Set the sprite to the open door sprite
            StartCoroutine(LoadNextSceneWithDelay());
        }

    }

    IEnumerator LoadNextSceneWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoad);

        player.GetComponent<PlayerMovement>().saveInfo(); // Save player info if needed

        SceneManager.LoadScene(sceneName: "LevelSelection2");
    }

}
