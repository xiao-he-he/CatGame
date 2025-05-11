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
    public GameObject lizi;
    public AudioClip clip;
    private bool isHolding = false; // 跟踪是否正在按住
    public bool holding = false;
    public override void OnPointerClick(PointerEventData eventData)
    {
        UIimage.SetActive(true);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        // 保持原样或添加进入时的效果
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        // 保持原样或添加退出时的效果
    }

    protected override void OnHold(float holdTime)
    {
        if(holding == false)
        
        { 
            AudioManage.Instant.PlayClip(clip,true);
           holding = true;
        }
       
        if (!isHolding)
        {
            // 开始按住时播放粒子效果
           
               lizi.SetActive(true);
            
            isHolding = true;
        }
        
        // 原有的移动逻辑
        float moveX = xSpeed * Time.deltaTime;
        float moveY = ySpeed * Time.deltaTime;
        Zhua.Translate(moveX, moveY, 0);
    }

    // 添加松开时的处理
    public override void OnPointerUp(PointerEventData eventData)
    {
        AudioManage.Instant.StopClip(clip); 
        base.OnPointerUp(eventData);

        if (isHolding ) lizi.SetActive(false);
          

        isHolding = false;
        holding = false;
    }
}