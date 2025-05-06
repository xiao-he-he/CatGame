using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using wakeupmodel;

public class WinOrLose : MonoBehaviour
{
    public GameObject WinUI;
    public GameObject AngryUI;
    public GameObject SleepUI;
  
    private void Win()
    {
        WinUI.SetActive(true);
    }
    private void Angry()
    {
        AngryUI.SetActive(true);
    }
    private void Sleep()
    {
        SleepUI.SetActive(true);
    }
    private void Update()
    {
        Debug.Log(WakeUpModel.Instance.AngryTime); 
        Debug.Log(WakeUpModel.Instance.SleepTime);
        Debug.Log(WakeUpModel.Instance.ComfotableTime);
        
        if (WakeUpModel.Instance.ComfotableTime >= 30f)
        {
            Win();
            Time.timeScale = 0f;

        }
        if (WakeUpModel.Instance.SleepTime >= 15f)
        {
            Sleep();
            Time.timeScale = 0f;
        }
        if (WakeUpModel.Instance.AngryTime >= 15f)
        {
            Angry();
            Time.timeScale = 0f;
        }

    }
}
