using Level.Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace View
{
    public class LevelSetting:MonoBehaviour
    {
        public AudioSource AudioSource;
        public GameObject UI;
        public Slider B, S; 
        public void OpenUI()
        {
            UI.SetActive(true);
            Time.timeScale = 0;
            AudioSource.Pause();
        }

        public void CloseUI()
        {
            UI.SetActive(!true);
            Time.timeScale = 1.0f;
            AudioSource.UnPause();
        }

        public void ReturnSelect()
        {
            SceneManager.LoadScene("Choose");
            AudioManage.Instant.ClearAll();
            Time.timeScale = 1.0f;
            AudioSource.UnPause();
        }

        public void ChangeBGM()
        {
            SystemModel.Instance.BGM = (1 - B.value);
        }

        public void ChangeSound()
        {
            SystemModel.Instance.Sound = (1 - S.value);
        }
    }
}