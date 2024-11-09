using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HumanBehaviour : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private DialogueObject dialogueObject;

    public DialogueUI DialogueUI => dialogueUI;

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
 
            dialogueUI.ShowDialogue(dialogueObject);
            StartCoroutine(loadScene());




        }
    }

    private IEnumerator loadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneName: "EndingScene");
       
    }

}
