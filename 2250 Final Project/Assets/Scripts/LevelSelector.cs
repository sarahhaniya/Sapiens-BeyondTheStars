using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // For event handling
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject levelSelectedImage; // Assign this in the Inspector
    public string sceneName;
    public GameObject levelImage;
    public GameObject window1;
    public GameObject window2;
    public GameObject window3;

    private void Start()
    {
  
        if (levelSelectedImage != null)
        {

            levelSelectedImage.SetActive(false);
            window1.SetActive(false);
            window2.SetActive(false);
            window3.SetActive(false);
        }

    }

    // When the mouse pointer enters the GameObject area
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter called for " + gameObject.name);

        Image levelImageComponent = levelImage.GetComponent<Image>();
        Image levelSelectedImgComponent = levelSelectedImage.GetComponent<Image>();


        levelSelectedImage.SetActive(true);

        if (levelSelectedImage != null)
        {

            levelSelectedImage.SetActive(true);
            Debug.Log(">>>>>>" + levelSelectedImgComponent.gameObject.name);
            Debug.Log(">>>>>>" + levelSelectedImgComponent.gameObject.transform.position.ToString());

            if (levelSelectedImage.activeSelf == true) {

                levelImage.SetActive(false);
                levelImageComponent.raycastTarget = false;
                levelSelectedImgComponent.raycastTarget = true;
            }


            // Conditionally activate windows based on gameObject.name
            if (gameObject.name == "hover1")
            {
                window1.SetActive(true);
            }
            else if (gameObject.name == "hover2")
            {
                window2.SetActive(true);
            }
            else if (gameObject.name == "hover3")
            {
                window3.SetActive(true);
            }


        }
    }

    // When the mouse pointer exits the GameObject area
    public void OnPointerExit(PointerEventData eventData)
    {

        window1.SetActive(false);
        window2.SetActive(false);
        window3.SetActive(false);
        Debug.Log("OnPointerExit called for " + gameObject.name);

        Image levelImageComponent = levelImage.GetComponent<Image>();
        Image levelSelectedImgComponent = levelSelectedImage.GetComponent<Image>();


        if (levelSelectedImage != null)
        {
            levelSelectedImage.SetActive(false);

            if (levelSelectedImage.activeSelf == false) {

                levelImage.SetActive(true);
                levelImageComponent.raycastTarget = true;
                levelSelectedImgComponent.raycastTarget = false;
            }
          

        }
    }

    public void ChangeScene() 
    {
        SceneManager.LoadScene(sceneName); // Call this function with the name of the scene you want to load
    }
}
