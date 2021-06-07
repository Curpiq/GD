using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject cell, redChecker, yellowChecker;
    float spacing = 1.09f;
    float startX = -0.6f;
    float startY = 2.5f;
    int [,] cells = new int[3,5] //столбцы + строки
    {
        {0, 1, 1, 0, 0},
        {0, 1, 1, 1, 0},
        {0, 0, 1, 1, 0}
    };
    
    int [,] checkers = new int[3,5]
    {
        {0, 1, 1, 0, 0},
        {0, 1, 0, 2, 0},
        {0, 0, 2, 2, 0}
    };
    // Start is called before the first frame update
    void Start()
    {
        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < 3; i++)
            {
                float x = startX + i*spacing;
                float y = startY - j*spacing;
                UnityEngine.Vector3 newPos = new UnityEngine.Vector3(x, y, 1);
                if (cells[i,j] == 1)
                {
                    Instantiate(cell, newPos, Quaternion.identity);
                }
                if (checkers[i,j] == 1)
                {
                    Instantiate(redChecker, newPos, Quaternion.identity);
                }
                else if (checkers[i,j] == 2)
                {
                    Instantiate(yellowChecker, newPos, Quaternion.identity);
                }
                cell.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("mid");
                yellowChecker.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("fore");
                redChecker.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("fore");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
