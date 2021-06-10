using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnClick : MonoBehaviour, IPointerClickHandler
{
    public Sprite clicked;
    private Vector3 newPos;
    private const int spaceSize = 11;
    private int cellWidth;
    static private GameObject obj;
    static private Sprite objSprite;

    static private string objName;

    private bool IsCorrectMove(double posCoord, double newPosCoord)
    {
        return (newPosCoord <= posCoord + ((cellWidth + spaceSize) * 2) && newPosCoord > posCoord) || (newPosCoord >= posCoord - ((cellWidth + spaceSize) * 2) && newPosCoord < posCoord);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (obj != null)
        {
            obj.GetComponent<Image>().sprite = objSprite;

            cellWidth = (int)obj.GetComponent<Image>().rectTransform.rect.width;

            Debug.Log(cellWidth);

            if (this.gameObject.name == "Cell" && objName == "Checker")
            {
                Debug.Log("1 if");
                Vector3 pos = obj.transform.position;
                double posX = Math.Round(pos.x);

                newPos = this.gameObject.transform.position;
                double newPosX = Math.Round(newPos.x);
                
                if ((newPos.x != pos.x && newPos.y == pos.y) || (newPos.x == pos.x && newPos.y != pos.y))
                {
                    Debug.Log("2 if");
                    Debug.Log(posX);
                    Debug.Log(newPos.x);
                    Debug.Log((posX - 282) + " <= " + newPosX + " <= " + (posX - 141));
                    if (IsCorrectMove(pos.y, newPos.y) || IsCorrectMove(posX, newPosX))
                    {
                        obj.transform.position = newPos;
                    }
                    
                }
            }
        }

        obj = this.gameObject;

        objSprite = this.GetComponent<Image>().sprite;

        objName = this.name;

        obj.GetComponent<Image>().sprite = clicked;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
