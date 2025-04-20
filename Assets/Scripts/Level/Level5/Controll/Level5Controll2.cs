using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5Controll2 : MonoBehaviour
{
    public GameObject roudian3;
    public GameObject roudian6;
    public string script;
    public GameObject UIimage;

   public void judge2()
    {
        UIimage.SetActive(false);
        if (roudian6.transform.position.x <= Level5Model.Instance.xLimitMax2 && roudian6.transform.position.x >= Level5Model.Instance.xLimitMin2)

        {
            MonoBehaviour targetScript = (MonoBehaviour)roudian3.GetComponent(script);
            targetScript.enabled = true;

        }
        else
        {
            SceneManager.LoadScene(6);
        }
    }

}