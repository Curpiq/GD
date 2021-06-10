using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public GameObject canvas; //Основной Canvas
    public UnityEngine.GameObject objP;
    // Start is called before the first frame update
    void Start()
    {
        int posX = -100;
        for (int i = 0; i < Win.GetStars(); i++)
        {
            GameObject star = Instantiate(objP, objP.transform.position = new Vector3(0 + posX, -10, 0), Quaternion.identity) as GameObject;
            star.transform.SetParent(canvas.transform, false);
            posX += 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
