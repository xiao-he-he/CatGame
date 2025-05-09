using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class CardSelect : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler
{
    public delegate void Chick();

    [Header("跳转的关卡数")]
    public string level ;

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
        SceneManager.LoadScene(level);
    }
}
