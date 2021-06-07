using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    static private int levelCount = 2;
    private GameObject[] checkersSet1;
    private GameObject[] checkersSet2;

    private List<Vector3> chekersPos1 = new List<Vector3>();
    private List<Vector3> chekersPos2 = new List<Vector3>();

    private bool isWin = false;


    void Start()
    {
        checkersSet1 = GameObject.FindGameObjectsWithTag("Checker1");
        for (int i = 0; i < checkersSet1.Length; i++)
        {
            chekersPos1.Insert(i, checkersSet1[i].transform.position);
        }

        checkersSet2 = GameObject.FindGameObjectsWithTag("Checker2");
        for (int i = 0; i < checkersSet2.Length; i++)
        {
            chekersPos2.Insert(i, checkersSet2[i].transform.position);
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
            for (int j = 0; j < chekersPos2.Count; j++)
            {
                if (checkersSet1[i].transform.position == chekersPos2[j])
                {
                    counter1++; 
                }
            }
        }

        int counter2 = 0;
        for (int i = 0; i < checkersSet2.Length; i++)
        {
            for (int j = 0; j < chekersPos1.Count; j++)
            {
                if (checkersSet2[i].transform.position == chekersPos1[j])
                {
                    counter2++; 
                }
            }
        }

        if (counter1 == checkersSet1.Length && counter2 == checkersSet2.Length)
        {
            Debug.Log("Win!!");
            isWin = true;
            if (SceneManager.GetActiveScene().buildIndex + 1 > 2)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
