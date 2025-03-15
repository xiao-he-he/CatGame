using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Catdisappear : BaseItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        transform.parent.gameObject.SetActive(false); // Òþ²ØÃ¨
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
       
    }
}
