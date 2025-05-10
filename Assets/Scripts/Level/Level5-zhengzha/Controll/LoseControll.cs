using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using View.Select;

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
                SceneManager.LoadScene("Level_5");
            }
        }
        else
        {
            EndUI.DefeatUI(Resources.Load<Sprite>("Image/Defeat/Level5/Hurt"));
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
            Debug.Log("�ɵ� Level 5 �浵��ɾ����׼����ʼ����");
        }
    }

}
