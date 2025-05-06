using System;
using System.Collections;
using System.Collections.Generic;
using Level.Contronal;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseItem : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    protected BaseLevelController _controller;

    protected virtual void Start()
    {
        _controller = BaseLevelController.Instance;
    }

    public abstract void OnPointerClick(PointerEventData eventData);

    public virtual void OnPointerEnter(PointerEventData eventData){}

    public virtual void OnPointerExit(PointerEventData eventData){}
    
}
