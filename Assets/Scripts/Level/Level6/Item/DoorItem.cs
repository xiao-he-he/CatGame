using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorItem : BaseItem
{
    public GameObject Door;
    public GameObject Cat;
    public bool IsDoor;
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (IsDoor)
        {
            Cat.SetActive(true);
Door.SetActive(false);
            IsDoor = false;
        }
        else
        {
            Cat.SetActive(false);
         Door.SetActive(true);
            IsDoor = true;
        }
       
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {

    }
    public override void OnPointerExit(PointerEventData eventData)
    {

    }
}
