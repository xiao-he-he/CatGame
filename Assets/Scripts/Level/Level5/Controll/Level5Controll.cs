
using UnityEngine;
using UnityEngine.SceneManagement;
using View.Select;

public class Level5Controll : MonoBehaviour
{

    public GameObject roudian2;
   
    
    public GameObject roudian5;


    public AudioClip clip1;
    public AudioClip clip2;
    public string script;
    public GameObject UIimage;
    public GameObject chou;
    public GameObject blood;
    public bool isPlay = false;
    private void Start()
    {
        AudioManage.Instant.PlayClip(clip1, true);
    }
    private void Update()
    { 
       
        if(roudian5.transform.position.x >= 0.165f&&Level5Model.Instance.isSun)
        {
            if(isPlay == false) 
            {
                AudioManage.Instant.StopClip(clip1);
            AudioManage.Instant.PlayClip(clip2);
                isPlay = true;
            }
            
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
            Level5Model.Instance.istwo = true;
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


