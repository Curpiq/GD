using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] checkersSet1;
    private GameObject[] checkersSet2;

    private List<Vector3> checkersPos1 = new List<Vector3>();
    private List<Vector3> checkersPos2 = new List<Vector3>();

    private bool isWin = false;

    private static int stars;

    public static void SetStars(int count)
    {
        stars = count;
    }

    public static int GetStars()
    {
        return stars;
    }

    void Start()
    {
        checkersSet1 = GameObject.FindGameObjectsWithTag("Checker1");
        for (int i = 0; i < checkersSet1.Length; i++)
        {
            checkersPos1.Insert(i, checkersSet1[i].transform.position);
        }

        checkersSet2 = GameObject.FindGameObjectsWithTag("Checker2");
        for (int i = 0; i < checkersSet2.Length; i++)
        {
            checkersPos2.Insert(i, checkersSet2[i].transform.position);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isWin)
        {
            return;
        }
        int counter1 = 0;
        for (int i = 0; i < checkersSet1.Length; i++)
        {
            for (int j = 0; j < checkersPos2.Count; j++)
            {
                if (checkersSet1[i].transform.position == checkersPos2[j])
                {
                    counter1++; 
                }
            }
        }
        
        int counter2 = 0;
        for (int i = 0; i < checkersSet2.Length; i++)
        {
            for (int j = 0; j < checkersPos1.Count; j++)
            {
                if (checkersSet2[i].transform.position == checkersPos1[j])
                {
                    counter2++; 
                }
            }
        }

       

        if (counter1 == checkersSet1.Length && counter2 == checkersSet2.Length)
        {
            Debug.Log("Win!! Stars:" + stars);
            isWin = true;
            SceneManager.LoadScene(1);
            SceneController.SetNextLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
