
using UnityEngine;
using UnityEngine.SceneManagement;
using View.Select;

public class Level5Controll3 : MonoBehaviour
{
    public AudioClip clip1;
    public AudioClip clip2;
    public GameObject roudian4;
    public GameObject roudian7;
    public string script;
    public GameObject UIimage;
    public GameObject chou;
    public GameObject blood;
        public bool isPlay;
   
        
    
   
    private void Update()
    {
        if (Level5Model.Instance.isthree)
        {
            AudioManage.Instant.PlayClip(clip1, true);
        Level5Model.Instance.isthree = false;
        }
        if (roudian7.transform.position.x <= -0.065f && Level5Model.Instance.isSun)
        {
            if (isPlay == false)
            {
                AudioManage.Instant.StopClip(clip1);
                AudioManage.Instant.PlayClip(clip2, true);
                isPlay = true;
            }
            blood.SetActive(true);
        }
    }
    public void judge3()
    {
        AudioManage.Instant.StopClip(clip2);
        UIimage.SetActive(false);
        blood.SetActive(false);
        if (roudian7.transform.position.x <= Level5Model.Instance.xLimitMax3 && roudian7.transform.position.x >= Level5Model.Instance.xLimitMin3)

        {
            Level5Model.Instance.isfour = true;
            MonoBehaviour targetScript = (MonoBehaviour)roudian4.GetComponent(script);
            targetScript.enabled = true;
           
            chou.SetActive(true);
           
            
        }
        else if (roudian7.transform.position.x > Level5Model.Instance.xLimitMin3)
        {
            SceneManager.LoadScene("Level_5_ZhengZha");
        }
        else
        {
            EndUI.DefeatUI(Resources.Load<Sprite>("Image/Defeat/Level5/Hurt"));
        }
    }
   
}