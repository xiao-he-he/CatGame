using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace View
{
    public class SelectUI:MonoBehaviour
    {
        public void ReturnToMain()
        {
            SceneManager.LoadScene("Start");
        }
    }
}