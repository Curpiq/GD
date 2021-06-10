using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    static private int levelCount = 5;

    static private int firstLevelIndex = 3;
    static private int nextLevel;

    static private int prevSceneIndex;
    public void Play(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public static void SetNextLevel(int level)
    {
        nextLevel = level;
    }
    public void NextLevel()
    {
        if (nextLevel >= levelCount + 3)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(nextLevel);
        }
        // SceneManager.LoadScene(nextLevel);
        // if (SceneManager.GetActiveScene().buildIndex + 1 > levelCount + 1)
        // {
        //     SceneManager.LoadScene(0);
        // }
        // else
        // {
        //     if
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(prevSceneIndex);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex < firstLevelIndex)
        {
            TimerLevel.SetFlag(false);
        }
        else
        {
            prevSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
