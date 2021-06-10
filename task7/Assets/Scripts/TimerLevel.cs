using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimerLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public int sceneNumber;
    private float currentTime;

    private float startTime;
    static private bool flag = false;
    private Text counterText;
    void Start()
    {
        counterText = GetComponent<Text>() as Text;
        Debug.Log("timer start");
    }

    public static void SetFlag(bool _flag)
    {
        flag = _flag;
    }

    void SetTime(float _minutes, float _seconds)
    {
        counterText.text = _minutes.ToString("00") + ":" + _seconds.ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        // if (SceneManager.GetActiveScene().buildIndex >= 2)
        // {
        //     minutes = (int)(Time.time/60f);
        //     seconds = (int)(Time.time % 60f);
        //     SetTime(minutes, seconds);
        //     if (seconds >= 30)
        //     {
        //         counterText.color = new Color(255/255.0f, 121/255.0f, 0/255.0f, 255/255.0f);
        //     }
        //     if (seconds >= 50)
        //     {
        //         counterText.color = new Color(255/255.0f, 0/255.0f, 0/255.0f, 255/255.0f);
        //     }
        //     if (minutes >= 1)
        //     {
        //         SceneManager.LoadScene(0);
        //         SetTime(0f, 0f);
        //     }
        // }
        // else
        // {
        //     Debug.Log("err");
        //     return;
        // }
        // minutes = (int)(Time.time/60f);
        // seconds = (int)(Time.time % 60f);

        currentTime = Time.time;

        if (SceneManager.GetActiveScene().buildIndex == sceneNumber)
        {
            if (!flag)
            {
                startTime = currentTime;
            }

            SetTime((int)(currentTime - startTime)/60, (int)(currentTime - startTime) % 60);

            flag = true;

            Win.SetStars(3);

            if ((currentTime - startTime) % 60f >= 30)
            {
                counterText.color = new Color(255/255.0f, 121/255.0f, 0/255.0f, 255/255.0f);
                Win.SetStars(2);
            }
            if ((currentTime - startTime) % 60f >= 50)
            {
                counterText.color = new Color(255/255.0f, 0/255.0f, 0/255.0f, 255/255.0f);
                Win.SetStars(1);
            }
            if ((currentTime - startTime)/60f >= 1)
            {
                //Win.SetStars(0);
                SceneManager.LoadScene(2);
            }
        }
        

        

    }
}
