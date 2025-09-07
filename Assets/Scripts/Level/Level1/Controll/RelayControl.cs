using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using level1model;

public class RelayControl : MonoBehaviour
{
    public Text minusTimeText; // 在Inspector中设置好位置和样式的Text组件
    private float textDisplayTime = 0f;
    private Coroutine textDisplayCoroutine;

    void Start()
    {
        // 初始隐藏文本
        if (minusTimeText != null)
        {
            minusTimeText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("CatItemTag") && hit.collider.gameObject.activeInHierarchy)
                {
                    ExecuteEvents.Execute(hit.collider.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                }
                else
                {
                    HandleMissClick();
                }
            }
            else
            {
                HandleMissClick();
            }
        }
    }

    void HandleMissClick()
    {
        if (Time.timeScale > 0f)
        {
            Debug.Log("Miss，time +5");
            Level1Model.Instance.time += 5f;
            Level1Model.Instance.AllTime += 5f;
            Level1Model.Instance.Timing -= 5f;
        }

        // 显示"-5s"文字
        ShowMinusTimeText();
    }

    void ShowMinusTimeText()
    {
        if (minusTimeText != null)
        {
            // 停止之前的显示协程（如果存在）
            if (textDisplayCoroutine != null)
            {
                StopCoroutine(textDisplayCoroutine);
            }

            // 重置文本并显示
            if (Time.timeScale > 0f)
            {
                minusTimeText.text = "-5s";
                minusTimeText.gameObject.SetActive(true);
            }
        

            // 启动新的显示协程
            textDisplayCoroutine = StartCoroutine(HideTextAfterDelay(0.5f));
        }
    }

    IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        minusTimeText.gameObject.SetActive(false);
        textDisplayCoroutine = null;
    }
}