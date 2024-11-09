using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath1 : MonoBehaviour
{
    public static bool isPlayerDead;
    public GameObject Panel;

    private void Awake()
    {
        isPlayerDead = false;

        if (Panel != null)
        {
            Panel.SetActive(false);
        }
        else
        {
            Debug.LogError("Panel reference is not set!");
        }

    }

    void Update()
    {
        if (isPlayerDead)
        {
            Panel.SetActive(true);
        } 
    }

    public void Restart()
    {
        SceneManager.LoadScene("FallingObject");
    }
}
