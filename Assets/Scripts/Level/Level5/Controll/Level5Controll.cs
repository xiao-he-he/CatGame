using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5Controll : MonoBehaviour
{

    public GameObject roudian2;
   
    
    public GameObject roudian5;
   
    
   
    public string script;
    public GameObject UIimage;
    
  public void judge1()
    {
        UIimage.SetActive(false);
        if (roudian5.transform.position.x <= Level5Model.Instance.xLimitMax1&& roudian5.transform.position.x >= Level5Model.Instance.xLimitMin1)
  
        {
            MonoBehaviour targetScript = (MonoBehaviour)roudian2.GetComponent(script);
            targetScript.enabled = true;
            
            
        }
        else
        {
            SceneManager.LoadScene(6);
        }
        
       
    }
   
}
