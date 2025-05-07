using System.Collections;
using System.Collections.Generic;
using level1model;
using UnityEngine;
using UnityEngine.UI;
public class Level1TimeControll : MonoBehaviour
{
    public Text timeText;       // 用于显示时间的Text组件
    public Text catCountText;   // 用于显示猫数量的Text组件
    public float initialTime = 180f; // 初始时间（3分钟=180秒）
  

    void Start()
    {
        // 初始化剩余时间
        Level1Model.Instance.Timing = initialTime;
    }

    void Update()
    { 

        // 更新倒计时
        UpdateCountdown();

        // 更新时间显示（格式化为分钟:秒钟）
        UpdateTimeDisplay();

        // 更新猫数量显示
        UpdateCatCountDisplay();
    }

    void UpdateCountdown()
    {
        // 只在时间未结束时倒计时
        if (Level1Model.Instance.Timing > 0)
        {
            // 减去帧时间
            Level1Model.Instance.Timing -= Time.deltaTime;

            // 确保时间不小于0
            Level1Model.Instance.Timing = Mathf.Max(0, Level1Model.Instance.Timing);

           
            // 可选：时间结束时的处理
            if (Level1Model.Instance.Timing <= 0)
            {
                TimeExpired();
            }
        }
    }

    void TimeExpired()
    {
        // 时间结束时的逻辑
        Debug.Log("时间到！");
        // 这里可以添加游戏结束或其他逻辑
    }

    void UpdateTimeDisplay()
    {
        // 计算分钟和秒钟
        int minutes = Mathf.FloorToInt(Level1Model.Instance.Timing / 60f);
        int seconds = Mathf.FloorToInt(Level1Model.Instance.Timing % 60f);

        // 格式化为两位数显示（如01:05）
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        // 更新Text组件
        if (timeText != null)
        {
            timeText.text = timeString;
        }
    }

    void UpdateCatCountDisplay()
    {
        if (catCountText != null)
        {
            // 显示猫数量（如"15/20"）
            catCountText.text = Level1Model.Instance.CatModel + "/20";
        }
    }

    // 可选：添加时间的方法
    public void AddTime(float secondsToAdd)
    {
        Level1Model.Instance.Timing += secondsToAdd;
    }
}