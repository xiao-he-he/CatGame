using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace View
{
    public class EndUI:MonoBehaviour
    {
        public async void Exit()
        {
            var g = Instantiate(Resources.Load<GameObject>("Prefab/Loading"));
            var TSlider = g.transform.GetChild(1).GetComponent<Slider>();
            while (TSlider.value<1)
            {
                TSlider.value += 0.1f;
                await UniTask.WaitForSeconds(0.1f);
            }
            
            SceneManager.LoadScene("Choose");
        }

        public async void ReStart()
        {  var g = Instantiate(Resources.Load<GameObject>("Prefab/Loading"));
            var TSlider = g.transform.GetChild(1).GetComponent<Slider>();
            while (TSlider.value<1)
            {
                TSlider.value += 0.1f;
                await UniTask.WaitForSeconds(0.1f);
            }
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}