using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View.Select;

public class Level6WinControll : MonoBehaviour
{
    public bool Time = true;
    public GameObject WinUI;    // 胜利时显示的UI物体
    public GameObject Cat;      // 失败时显示的猫物体
    public float checkDelay = 5f; // 检测延迟时间(秒)

    private void Start()
    {
        StartCoroutine(CheckDoorStatusAfterDelay());
    }
    public void Update()
    {
        if (Level6Model.Instance.IsDoor&&Time)
        {
            ShowWinUI();
        }
    }
    private IEnumerator CheckDoorStatusAfterDelay()
    {
        // 等待指定时间
        yield return new WaitForSeconds(checkDelay);

        // 检查门状态

        
        if(Level6Model.Instance.IsDoor== false)
        {
            Time = false;
            ShowCat();
        }


        
    }

    private void ShowWinUI()
    {

        EndUI.WinUI(Resources.Load<Sprite>("Image/Win/Level6S"));


    }

    private void ShowCat()
    {
            Cat.SetActive(true);

        
    }
}
