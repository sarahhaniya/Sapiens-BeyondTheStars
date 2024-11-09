using System.Diagnostics;
using UnityEngine;

// Make sure to include the EventSystems namespace if using IsPointerOverGameObject
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickableSpriteBehaviour : MonoBehaviour, IPointerDownHandler
{
    public string levelName;
    public void OnPointerDown(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("Sprite Clicked!");

        // Call your scene change method here
        ChangeScene();
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(levelName);
    }
}
