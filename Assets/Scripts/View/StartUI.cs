using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace View
{
    public class StartUI:MonoBehaviour
    {
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
        
    }
}