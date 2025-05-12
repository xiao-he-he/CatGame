using UnityEngine;
using UnityEngine.EventSystems;
using View;

public class SettingItem : BaseItem
{
    public GameObject canvas;
    public override void OnPointerClick(PointerEventData eventData)
    {
        canvas.GetComponent<LevelSetting>().OpenUI();
    }
    public override void OnPointerEnter(PointerEventData eventData) 
    { 

    }
    public override void OnPointerExit(PointerEventData eventData) 
    {

    }
}

