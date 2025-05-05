using System;
using System.Collections;
using System.Collections.Generic;
using Level.Contronal;
using Level.Model;
using UnityEngine;
using wakeupmodel;


public class WakeUpControll : BaseLevelController
{
    public Transform UI; // 物体1
    public GameObject angry;
    public GameObject sleep;
    public Vector3 offset1;
    public Vector3 offset2;
    private float number = 0f;

    private bool isTimer1Running = false;
    private bool isTimer2Running = false;
    private bool isTimer3Running = false;
   
    void Update()
    {
        if (isTimer1Running)
        {
            WakeUpModel.Instance.SleepTime += Time.deltaTime;
        }

        if (isTimer2Running)
        {
            WakeUpModel.Instance.AngryTime += Time.deltaTime;
        }

        if (isTimer3Running)
        {
            WakeUpModel.Instance.ComfotableTime += Time.deltaTime;
        }



        number = WakeUpModel.Instance.GetFrequency() - WakeUpModel.Instance.FrequencyRange;

        // 根据 number 值来移动物体1
        if (number > 0& UI.position.y <= 3.7)
        {
            // 向上移动
            UI.position += offset1*Time.deltaTime;
        }
        else if (number < 0& UI.position.y >= -3.7 )
        {
            // 向下移动
            UI.position -= offset2 * Time.deltaTime;
        }
        if (UI.position.y <= -1.0)
        {
            sleep.SetActive(true);
            
            angry.SetActive(false);
            isTimer1Running = true;
            isTimer2Running = false;
            isTimer3Running = false;
        }
       
        else if (UI.position.y >= +1.0)
        {
            angry.SetActive(true);
            sleep.SetActive(false);
            isTimer1Running = false;
            isTimer2Running = true; 
            isTimer3Running = false;



        }
        else
        {
            angry.SetActive(false);
            sleep.SetActive(false);
            isTimer1Running = false;
            isTimer2Running = false;
            isTimer3Running = true;

        }


    }
}


