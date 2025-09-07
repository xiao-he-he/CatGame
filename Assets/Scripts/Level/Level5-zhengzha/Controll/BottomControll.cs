using System.Collections;
using System.Collections.Generic;
using level1model;
using UnityEngine;
using UnityEngine.EventSystems;

public class BottomControll : BaseItem
{
    [Header("动画控制")]
   
    public Animator jKeyAnimator;   
    public string jKeyAnimation = "Animation3";
    public string dKeyAnimation = "Animation1"; // D键播放的动画名称
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


            jKeyAnimator.SetTrigger(dKeyAnimation);
            targetObject.transform.localScale = scale;

            cooldownTimer = cooldownTime;
            Delay();
           jKeyAnimator.SetTrigger(jKeyAnimation);

        }
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
      
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
       
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.01f);
    }
}

