using System.Collections;
using System.Collections.Generic;
using level1model;
using UnityEngine;
using UnityEngine.EventSystems;

public class BottomControll : BaseItem
{
    public GameObject targetObject; 
    private float cooldownTime = 0.1f;
    private float cooldownTimer = 0f;

    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (cooldownTimer <= 0f && targetObject != null)
        {
            Vector3 scale = targetObject.transform.localScale;
            scale.x -= 0.02f;

            

            targetObject.transform.localScale = scale;

            cooldownTimer = cooldownTime;
        }
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
      
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
       
    }
}

