
using Cysharp.Threading.Tasks;
using Level.Model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Slider = UnityEngine.UI.Slider;

public class CardSelect : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler
{
    public delegate void Chick();

    [Header("跳转的关卡数")]
    public int level ;

    public UnityEngine.UI.Slider TSlider;
    public GameObject ui;
    
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale *= 1.25f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale /= 1.25f;
    }

    public async void OnPointerDown(PointerEventData eventData)
    {
        var g = Instantiate(Resources.Load<GameObject>("Prefab/Loading"));
        TSlider = g.transform.GetChild(1).GetComponent<Slider>();
        while (TSlider.value<1)
        {
            TSlider.value += 0.1f;
            await UniTask.WaitForSeconds(0.1f);
        }

        SystemModel.Instance.ThisLevel = level; 
        switch (level)
        {
            case 1:
                SceneManager.LoadScene("Level_1");
                break;
            case 2:
                SceneManager.LoadScene("Level_2");
                break;
            case 3:
                SceneManager.LoadScene("Level_3");
                break;
            case 4:
                SceneManager.LoadScene("Level_4");
                break;
            case 5:
                SceneManager.LoadScene("Level_5");
                break;
            case 6:
                SceneManager.LoadScene("Level_6");
                break;
        }
        
    }
}
