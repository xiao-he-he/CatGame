
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using View.Select;

public class Level5Controll4 : MonoBehaviour
{
    public GameObject roudian8;

    public GameObject UIimage;
    public AudioClip clip1;
    public AudioClip clip2;

    public GameObject WinUI;
    public GameObject blood;
    public bool isPlay = false;
    private void Update()
    {
        if (Level5Model.Instance.isfour)
        {
            AudioManage.Instant.PlayClip(clip1, true);
        Level5Model.Instance.isfour = false;
        }
        if (roudian8.transform.position.x <= -0.165f && Level5Model.Instance.isSun)
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
    public void lastjudge()
    {
        AudioManage.Instant.StopClip(clip2);
        UIimage.SetActive(false);
        blood.SetActive(false);
        Level5Model.Instance.isSun = false;
        if (roudian8.transform.position.x <= Level5Model.Instance.xLimitMax4 && roudian8.transform.position.x >= Level5Model.Instance.xLimitMin4)
        {

            EndUI.WinUI(Resources.Load<Sprite>("Image/Win/Level5S"));
        }
        else if (roudian8.transform.position.x > Level5Model.Instance.xLimitMin4)
        {
            SceneManager.LoadScene("Level_5_ZhengZha");
        }
        else
        {
            EndUI.DefeatUI(Resources.Load<Sprite>("Image/Defeat/Level5/Hurt"));
        }
    }
    public void win()
    {
        ResetLevel5Data();
        SceneManager.LoadScene(7);
    }
    public void back()
    {
        ResetLevel5Data();
        SceneManager.LoadScene(0);    
    }
    private void ResetLevel5Data()
    {
        string path = Application.persistentDataPath + "/level5.dat";
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("�ɵ� Level 5 �浵��ɾ����׼����ʼ����");
        }
    }
}
