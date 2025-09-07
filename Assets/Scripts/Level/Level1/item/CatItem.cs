using System.Collections;
using System.Collections.Generic;
using Level.Contronal;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;
using level1model;

public class CatItem : BaseItem
{
   public AudioClip clip;
    public override void OnPointerClick(PointerEventData eventData)
    {
        AudioManage.Instant.PlayClip(clip);
            gameObject.SetActive(false);
            Level1Model.Instance.CatModel++;
            Debug.Log($"调用次数: {Level1Model.Instance.CatModel}");
       
    }

    

    public override void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
       
    }

}
