using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using View.Select;

public class Level5Controll : MonoBehaviour
{

    public GameObject roudian2;
   
    
    public GameObject roudian5;
   
    
   
    public string script;
    public GameObject UIimage;
    public GameObject chou;
    public GameObject blood;
    private void Update()
    {
        if(roudian5.transform.position.x >= 0.165f&&Level5Model.Instance.isSun)
        {
            blood.SetActive(true);
        }
    }

    public void judge1()
    {
        UIimage.SetActive(false);
        blood.SetActive(false);
        Level5Model.Instance.isSun = false;
        if (roudian5.transform.position.x <= Level5Model.Instance.xLimitMax1&& roudian5.transform.position.x >= Level5Model.Instance.xLimitMin1)
  
        {
            MonoBehaviour targetScript = (MonoBehaviour)roudian2.GetComponent(script);
            targetScript.enabled = true;
            chou.SetActive(true);
        }
        else if(roudian5.transform.position.x > Level5Model.Instance.xLimitMax1)
        {
            SceneManager.LoadScene("Level_5_ZhengZha");
        }
        else if (roudian5.transform.position.x <= Level5Model.Instance.xLimitMin1)
        {
            EndUI.DefeatUI(Resources.Load<Sprite>("Image/Defeat/Level5/Hurt"));
        }
       
    }
    
}


