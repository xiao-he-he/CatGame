using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackItem : BaseItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(0);
    }
    public override void OnPointerEnter(PointerEventData eventData) 
    { 

    }
    public override void OnPointerExit(PointerEventData eventData) 
    {

    }
}

