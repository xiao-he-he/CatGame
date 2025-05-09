using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using View.Select;

public class Level5Controll4 : MonoBehaviour
{
    public GameObject roudian8;

    public GameObject UIimage;

    public GameObject WinUI;
    public GameObject blood;
    private void Update()
    {
        if (roudian8.transform.position.x <= -0.165f && Level5Model.Instance.isSun)
        {
            blood.SetActive(true);
        }
    }
    public void lastjudge()
    {
        UIimage.SetActive(false);
        blood.SetActive(false);
        Level5Model.Instance.isSun = false;
        if (roudian8.transform.position.x <= Level5Model.Instance.xLimitMax4 && roudian8.transform.position.x >= Level5Model.Instance.xLimitMin4)
        {

            EndUI.WinUI(Resources.Load<Sprite>("Image/Win/Level5S"));
        }
        else if (roudian8.transform.position.x > Level5Model.Instance.xLimitMin4)
        {
            SceneManager.LoadScene("Level_5_ZhengZha");
        }
        else
        {
            EndUI.DefeatUI(Resources.Load<Sprite>("Image/Defeat/Level5/Hurt"));
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
