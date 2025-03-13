using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CardSelect : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler
{
    public delegate void Chick();

    [Header("跳转的关卡数")]
    public int level = 0;
    
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale *= 1.25f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale /= 1.25f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //跳转到相应官咖
    }
}
