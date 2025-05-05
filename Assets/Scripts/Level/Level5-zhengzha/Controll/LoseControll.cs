using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LoseControll : MonoBehaviour
{

    public GameObject targetObject; 

    private float timeElapsed = 0f;
    private float timeLimit = 6f;
    private bool sceneSwitched = false;

    public GameObject LoseUI;
    void Update()
    {

        timeElapsed += Time.deltaTime;

        if (timeElapsed <= timeLimit)
        {
            float scaleX = targetObject.transform.localScale.x;

            if (scaleX <= 0.02f)
            {
                Time.timeScale = 0f;
                SceneManager.LoadScene(5);
                Time.timeScale = 1f;

            }
        }
        else
        {
            LoseUI.SetActive(true);
        }
        
    }
    public void Back()
    {
        ResetLevel5Data();
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        ResetLevel5Data();
        SceneManager.LoadScene(5);
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
