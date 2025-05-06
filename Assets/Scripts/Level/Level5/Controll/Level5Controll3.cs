using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Level5Controll3 : MonoBehaviour
{
    public GameObject roudian4;
    public GameObject roudian7;
    public string script;
    public GameObject UIimage;
    public GameObject chou;

    public void judge3()
    {
        UIimage.SetActive(false);
        if (roudian7.transform.position.x <= Level5Model.Instance.xLimitMax3 && roudian7.transform.position.x >= Level5Model.Instance.xLimitMin3)

        {
            MonoBehaviour targetScript = (MonoBehaviour)roudian4.GetComponent(script);
            targetScript.enabled = true;
           
            chou.SetActive(true);
           
            
        }
        else
        {
            SceneManager.LoadScene(6);
        }
    }
   
}