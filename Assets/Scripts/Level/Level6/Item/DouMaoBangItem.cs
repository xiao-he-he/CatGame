using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DouMaoBangItem : Level5BaseItem
{
    private bool isDragging = false;
    private Vector3 offset;
    private Collider2D targetArea;
    private bool isInTargetArea = false;
    private float fixedZPosition; // 存储固定的Z坐标


    public GameObject targetZone;
    private Vector3 initialPosition;

    private void Start()
    {
        fixedZPosition = transform.position.z; // 初始化时保存Z坐标
        initialPosition = transform.position;  // 保存初始位置

        if (targetZone != null)
        {
            targetArea = targetZone.GetComponent<Collider2D>();

            if (targetArea == null)
            {
                Debug.LogError("目标区域缺少 Collider2D 组件！");
            }
        }
        else
        {
            Debug.LogError("targetZone 未赋值！");
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        // 点击逻辑
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        // 鼠标进入逻辑
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        // 鼠标离开逻辑
    }

    protected override void OnHold(float HoldTime)
    {
        if (!isDragging)
        {
            isDragging = true;
            // 获取鼠标位置并固定Z坐标
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = fixedZPosition;
            offset = transform.position - mousePosition;
        }
    }

    private void Update()
    {
        if (isDragging)
        {
            // 获取鼠标位置并固定Z坐标
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = fixedZPosition;
            transform.position = mousePosition + offset;

            if (targetArea != null)
            {
                isInTargetArea = targetArea.OverlapPoint(transform.position);
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                OnDrop();
            }
        }
    }


    private void OnDrop()
    {
        if (isInTargetArea)
        {
            SceneManager.LoadScene(8);
        }
        else
        {
            Debug.Log("未进入目标区域，回到原位置。");
            transform.position = initialPosition;

          
           
        }
    }

}
