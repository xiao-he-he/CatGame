using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace View
{
    public class SelectUI:MonoBehaviour
    {
        public void ReturnToMain()
        {
            SceneManager.LoadScene("Start");
            AudioClip a = null;
            AudioManage.Instant.PlayClip(a,true);
            AudioManage.Instant.PlayClip(a);
            AudioManage.Instant.StopClip(a);
        }
    }
}