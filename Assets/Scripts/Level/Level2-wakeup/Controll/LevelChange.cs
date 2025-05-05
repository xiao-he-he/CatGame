using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using wakeupmodel;

public class LevelChange : MonoBehaviour
{
    public GameObject restartUI1; public GameObject restartUI2;
    public void next()
    {
        Time.timeScale = 1.0f;
        WakeUpModel.Instance.SleepTime = 0f;
        WakeUpModel.Instance.AngryTime = 0f;
        WakeUpModel.Instance.ComfotableTime = 0f;
        SceneManager.LoadScene(4);
        
    }
    public void Restart()
    {
       
        Time.timeScale = 1.0f;
        WakeUpModel.Instance.SleepTime = 0f;
        WakeUpModel.Instance.AngryTime = 0f;
        WakeUpModel.Instance.ComfotableTime = 0f;
        SceneManager.LoadScene(3);
        

    }
    public void Back()
    {
        Time.timeScale = 1.0f;
        WakeUpModel.Instance.SleepTime = 0f;
        WakeUpModel.Instance.AngryTime = 0f;
        WakeUpModel.Instance.ComfotableTime = 0f;
        SceneManager.LoadScene(0);
        
    }
}
