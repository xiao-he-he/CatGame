using System;
using Level.Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace View
{
    public class StartUI:MonoBehaviour
    {
        public Slider S, B;
        public GameObject MakerUI;
        public GameObject SettingUI;
        public void StartGame()
        {
            SceneManager.LoadScene("Choose");
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }

        public void Setting()
        {
            SettingUI.SetActive(true);
            
        }

        public void CloseSetting()
        {
            SettingUI.SetActive(false);
        }

        public void Maker()
        {
            MakerUI.SetActive(true);
        }

        public void CloseMaker()
        {
            MakerUI.SetActive(false);
        }
        public void ChangeBGM()
        {
            SystemModel.Instance.BGM -= (1 - B.value);
        }

        public void ChangeSound()
        {
            SystemModel.Instance.Sound -= (1 - S.value);
        }
    }
}