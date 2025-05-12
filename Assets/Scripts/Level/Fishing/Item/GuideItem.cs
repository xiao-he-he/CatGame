using UnityEngine;
using UnityEngine.EventSystems;
using View;

public class GuideItem : BaseItem
{
    public GameObject manager;
    public override void OnPointerClick(PointerEventData eventData)
    {
        manager.GetComponent<GuideUI>().OpenGuide();
    }
    public override void OnPointerEnter(PointerEventData eventData) 
    { 

    }
    public override void OnPointerExit(PointerEventData eventData) 
    {

    }
}

