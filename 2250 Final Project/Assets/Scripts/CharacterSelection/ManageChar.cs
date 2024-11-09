using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ManageChar : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public SpriteRenderer charSprite;
    public TextMeshProUGUI nameText;

    private int select = 0;


    //Logic for starting
    void Start()
    {
        CharUpdate(select);
    }

    //Logic for the next button
    public void NextOption()
    {
        select++;

        if(select >= characterDB.CharacterCount)
        {
            select = 0;
        }

        CharUpdate(select);
    }

    //Logic for the back button
    public void BackOption()
    {
        select--;
         
        if(select < 0)
        {
            select = characterDB.CharacterCount - 1;
        }
        CharUpdate(select);
    }
    private void CharUpdate(int selectOption)
    {
        Character character = characterDB.GetCharacter(selectOption);
        charSprite.sprite = character.charSprite;

        String player = charSprite.sprite.name;        //Saving what the current sprite the player is using
        PlayerPrefs.SetString("charName",player);

        nameText.text = character.characterName;
    }
}
 