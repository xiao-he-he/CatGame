using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace View
{
    public class StartUI:MonoBehaviour
    {
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
            
        }

        public void Maker()
        {
            
        }
        
    }
}