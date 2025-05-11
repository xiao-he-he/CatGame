using Cysharp.Threading.Tasks;
using Level.Level3.Model;
using Level.Level4.Model;
using Level.Model;
using level1model;
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
            AudioManage.Instant.ClearAll();
            while (TSlider.value<1)
            {
                TSlider.value += 0.1f;
                await UniTask.WaitForSeconds(0.1f);
            }

            ClearnModels();
            SceneManager.LoadScene("Choose");
        }

        public async void ReStart()
        {  var g = Instantiate(Resources.Load<GameObject>("Prefab/Loading"));
            var TSlider = g.transform.GetChild(1).GetComponent<Slider>();
            AudioManage.Instant.ClearAll();
            while (TSlider.value<1)
            {
                TSlider.value += 0.1f;
                await UniTask.WaitForSeconds(0.1f);
            }

            ClearnModels();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        void ClearnModels()
        {
            Level1Model.ClearModel();
            Level2Model.ClearModel();
            Level3Model.ClearModel();
            Level4Model.ClearModel();
            Level5Model.ClearModel();
            Level6Model.ClearModel();
        }
        
    }
}