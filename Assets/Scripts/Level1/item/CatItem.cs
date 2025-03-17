using System.Collections;
using System.Collections.Generic;
using Level.Contronal;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class CatItem : BaseItem
{

    
    public override void OnPointerClick(PointerEventData eventData)
    {

        catdisappear1();


    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
       
    }
    void ToggleObject(GameObject target, bool state)
    {
        if (target != null)
        {
            target.SetActive(state);
        }

    }
    public GameObject object1;

    public void catdisappear1()
    {

        Debug.Log("µã»÷");
        ToggleObject(object1, false);// Òþ²ØÃ¨
    }

}
