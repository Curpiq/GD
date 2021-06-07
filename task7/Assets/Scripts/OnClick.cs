using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnClick : MonoBehaviour, IPointerClickHandler
{
    public Sprite clicked;
    private Vector3 newPos;
    static private GameObject obj;
    static private Sprite objSprite;

    static private string objName;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (obj != null)
        {
            obj.GetComponent<Image>().sprite = objSprite;
            if (this.gameObject.name == "Cell" && objName == "Checker")
            {
                Vector3 pos = obj.transform.position;
                newPos = this.gameObject.transform.position;
                if ((newPos.x != pos.x && newPos.y == pos.y) || (newPos.x == pos.x && newPos.y != pos.y))
                {
                    obj.transform.position = newPos;
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
