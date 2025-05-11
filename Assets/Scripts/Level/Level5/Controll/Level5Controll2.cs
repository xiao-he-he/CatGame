
using Level.Level4.Item;
using UnityEngine;
using UnityEngine.SceneManagement;
using View.Select;

public class Level5Controll2 : MonoBehaviour
{
    public AudioClip clip1;
    public AudioClip clip2; 
    public GameObject roudian3;
    public GameObject roudian6;
    public string script;
    public GameObject UIimage;
    public GameObject chou;
    public GameObject blood;
    public bool isPlay = false;
    private void Update()
    {
        if (Level5Model.Instance.istwo) 
        { 
            AudioManage.Instant.PlayClip(clip1, true);
        Level5Model.Instance.istwo = false; 
        }
       
        if (roudian6.transform.position.x >= 0.065f && Level5Model.Instance.isSun)
        { if (isPlay == false) { AudioManage.Instant.StopClip(clip1);
                AudioManage.Instant.PlayClip(clip2, true);isPlay = true; }   
            
            blood.SetActive(true);
        }
    }
    public void judge2()
    {
        AudioManage.Instant.StopClip(clip2);
        UIimage.SetActive(false);
        blood.SetActive(false);
        if (roudian6.transform.position.x <= Level5Model.Instance.xLimitMax2 && roudian6.transform.position.x >= Level5Model.Instance.xLimitMin2)

        {
            Level5Model.Instance.isthree = true;
            MonoBehaviour targetScript = (MonoBehaviour)roudian3.GetComponent(script);
            targetScript.enabled = true;
            chou.SetActive(true);
           
        }
        else if(roudian6.transform.position.x > Level5Model.Instance.xLimitMax2)
        {
            SceneManager.LoadScene("Level_5_ZhengZha");
        }
        else
        {
            EndUI.DefeatUI(Resources.Load<Sprite>("Image/Defeat/Level5/Hurt"));
        }
    }
   
}