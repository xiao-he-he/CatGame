using System;
using System.Collections;
using System.Collections.Generic;
using Level.Contronal;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Level5BaseItem : MonoBehaviour,
    IPointerClickHandler,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler,
    IPointerUpHandler
{
    protected BaseLevelController _controller;
    private bool _isHolding = false;
    private float _holdTime = 0f;

    protected virtual void Start()
    {
        _controller = BaseLevelController.Instance;
    }

    
    public abstract void OnPointerClick(PointerEventData eventData);

    
    public abstract void OnPointerEnter(PointerEventData eventData);

  
    public abstract void OnPointerExit(PointerEventData eventData);

   
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        _isHolding = true;
        _holdTime = 0f;
        StartCoroutine(WhileHolding());
    }

    public virtual void OnRelease()
    {
        // 基类默认逻辑（可以是空的）
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        _isHolding = false;
    }

  
    private IEnumerator WhileHolding()
    {
        while (_isHolding)
        {
            _holdTime += Time.deltaTime;
            OnHold(_holdTime);  
            yield return null;
        }
    }

  
    protected virtual void OnHold(float holdTime)
    {
        
    }
}