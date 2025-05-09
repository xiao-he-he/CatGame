using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using View.Select;
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
            EndUI.WinUI(Resources.Load<Sprite>("Image/Win/Level2S"));
            Time.timeScale = 0f;

        }
        if (WakeUpModel.Instance.SleepTime >= 15f)
        {
            EndUI.DefeatUI(Resources.Load<Sprite>("Image/Defeat/Level2/Sleep"));
            Time.timeScale = 0f;
        }
        if (WakeUpModel.Instance.AngryTime >= 15f)
        {
            EndUI.DefeatUI(Resources.Load<Sprite>("Image/Defeat/Level2/Angry"));
            Time.timeScale = 0f;
        }

    }
}
