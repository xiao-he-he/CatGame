using Level.Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace View
{
    public class LevelSetting:MonoBehaviour
    {
        public GameObject UI;
        public Slider B, S; 
        public void OpenUI()
        {
            UI.SetActive(true);
        }

        public void CloseUI()
        {
            UI.SetActive(!true);
        }

        public void ReturnSelect()
        {
            SceneManager.LoadScene("Choose");
            AudioManage.Instant.ClearAll();
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