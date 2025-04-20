using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5Controll3 : MonoBehaviour
{
    public GameObject roudian4;
    public GameObject roudian7;
    public string script;
    public GameObject UIimage;

    public void judge3()
    {
        UIimage.SetActive(false);
        if (roudian7.transform.position.x <= Level5Model.Instance.xLimitMax3 && roudian7.transform.position.x >= Level5Model.Instance.xLimitMin3)

        {
            MonoBehaviour targetScript = (MonoBehaviour)roudian4.GetComponent(script);
            targetScript.enabled = true;

        }
        else
        {
            SceneManager.LoadScene(6);
        }
    }
}
