
using UnityEngine;
using UnityEngine.SceneManagement;
using View.Select;

public class Level5Controll2 : MonoBehaviour
{
    public GameObject roudian3;
    public GameObject roudian6;
    public string script;
    public GameObject UIimage;
    public GameObject chou;
    public GameObject blood;
    private void Update()
    {
        if (roudian6.transform.position.x >= 0.065f && Level5Model.Instance.isSun)
        {
            blood.SetActive(true);
        }
    }
    public void judge2()
    {
        UIimage.SetActive(false);
        blood.SetActive(false);
        if (roudian6.transform.position.x <= Level5Model.Instance.xLimitMax2 && roudian6.transform.position.x >= Level5Model.Instance.xLimitMin2)

        {
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