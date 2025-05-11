using UnityEngine;
using UnityEngine.SceneManagement;

namespace View
{
    public class LevelSetting:MonoBehaviour
    {
        public GameObject UI;
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
        
    }
}