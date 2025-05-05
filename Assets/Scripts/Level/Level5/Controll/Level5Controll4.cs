using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Level5Controll4 : MonoBehaviour
{
    public GameObject roudian8;

    public GameObject UIimage;

    public GameObject WinUI;

    public void lastjudge()
    {
        UIimage.SetActive(false);
        if (roudian8.transform.position.x <= Level5Model.Instance.xLimitMax4 && roudian8.transform.position.x >= Level5Model.Instance.xLimitMin4)
        {
            WinUI.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(6);
        }
    }
    public void win()
    {
        ResetLevel5Data();
        SceneManager.LoadScene(7);
    }
    public void back()
    {
        ResetLevel5Data();
        SceneManager.LoadScene(0);    
    }
    private void ResetLevel5Data()
    {
        string path = Application.persistentDataPath + "/level5.dat";
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("旧的 Level 5 存档已删除，准备初始化。");
        }
    }
}
