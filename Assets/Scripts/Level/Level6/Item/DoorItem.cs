using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorItem : BaseItem
{
    public GameObject Door;
    public GameObject Cat;
    
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (Level6Model.Instance.IsDoor)
        {
            Cat.SetActive(true);
Door.SetActive(false);
            Level6Model.Instance.IsDoor = false;
        }
        else
        {
            Cat.SetActive(false);
         Door.SetActive(true);
            Level6Model.Instance.IsDoor = true;
        }
       
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {

    }
    public override void OnPointerExit(PointerEventData eventData)
    {

    }
}
