using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5Controll4 : MonoBehaviour
{
    public GameObject roudian8;

    public GameObject UIimage;

    public void lastjudge()
    {
        UIimage.SetActive(false);
        if (roudian8.transform.position.x <= Level5Model.Instance.xLimitMax4 && roudian8.transform.position.x >= Level5Model.Instance.xLimitMin4)
        {
            SceneManager.LoadScene(7);
        }
        else
        {
            SceneManager.LoadScene(6);
        }
    }
}
