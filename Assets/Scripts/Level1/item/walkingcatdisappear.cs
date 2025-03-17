using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class walkingcatdisappear : BaseItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {

        var c = _controller as game1controller;
        c.catdisappear1();

    }

    public override void OnPointerEnter(PointerEventData eventData)
    {

    }

    public override void OnPointerExit(PointerEventData eventData)
    {

    }
}