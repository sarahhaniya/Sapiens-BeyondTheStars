using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingController : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    public Canvas Canvas;
    
     private void Awake()
    {
        if(playerMovement != null)
        {
        //    playerMovement.PlayerDied += PlayerDead;
        }
        if (Canvas.gameObject.activeSelf) 
        {
            Canvas.gameObject.SetActive(false);
        }
    }

    void PlayerDead()
    {
        Canvas.gameObject.SetActive(true);

        if (playerMovement != null)
        {
       //     playerMovement.PlayerDied -= PlayerDead;
        }
    }
    public void ClickRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
