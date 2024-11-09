using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    public int seconds, minutes;
    public string finalTime;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("finalTime", "0:00");
        AddToSecond();
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    private void AddToSecond()
    {
        seconds++;
        if (seconds > 59)
        {
            minutes++;
            seconds = 0;
        }

        timeText.text = (minutes < 10 ? "0" : "") + minutes + ":" + (seconds < 10 ? "0" : "") + seconds;

        Invoke(nameof(AddToSecond), 1);
    }

    public void StopTimer()
    {
        CancelInvoke(nameof(AddToSecond));
        finalTime = timeText.text;
        PlayerPrefs.SetString("finalTime", finalTime);
        timeText.text = "";
    }
}
