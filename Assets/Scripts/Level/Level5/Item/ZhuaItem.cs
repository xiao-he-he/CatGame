using System.Collections;
using System.Collections.Generic;
using Level.Model;
using UnityEngine;
using UnityEngine.EventSystems;
using wakeupmodel;

public class ZhuaItem : Level5BaseItem
{
    public GameObject UIimage;
    public float xSpeed;
    public float ySpeed;
    public Transform Zhua;
    
    public override void OnPointerClick(PointerEventData eventData)
    {

        UIimage.SetActive(true);

    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
      
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
      
    }

    protected override void OnHold(float holdTime)
    {
       
        float moveX = xSpeed * Time.deltaTime;
        float moveY = ySpeed * Time.deltaTime;
        Zhua.Translate(moveX, moveY, 0);
    }
}
