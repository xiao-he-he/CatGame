using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using View.Select;
using wakeupmodel;

public class WinOrLose : MonoBehaviour
{
    private bool Isc = true;
    public GameObject WinUI;
    public GameObject AngryUI;
    public GameObject SleepUI;
    public MonoBehaviour[] scriptsToDisable;
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

        if (Isc)
        {
            if (WakeUpModel.Instance.ComfotableTime >= 10f)
            {
                EndUI.WinUI(Resources.Load<Sprite>("Image/Win/Level2S"));
                foreach (var script in scriptsToDisable)
                {
                    script.enabled = false;
                }

                Isc = false;
            }
            if (WakeUpModel.Instance.SleepTime >= 2.5f)
            {
                EndUI.DefeatUI(Resources.Load<Sprite>("Image/Defeat/Level2/Sleep"));
                foreach (var script in scriptsToDisable)
                {
                    script.enabled = false;
                }
                Isc = false;
            }
            if (WakeUpModel.Instance.AngryTime >= 2.5f)
            {
                EndUI.DefeatUI(Resources.Load<Sprite>("Image/Defeat/Level2/Angry"));
                foreach (var script in scriptsToDisable)
                {
                    script.enabled = false;
                }
                Isc = false;
            }

        }
        
    }
}
