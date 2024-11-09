using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScene : MonoBehaviour
{

    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private DialogueObject dialogueObject;

    public DialogueUI DialogueUI => dialogueUI;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.ShowDialogue(dialogueObject);

    }


}
