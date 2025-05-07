using UnityEngine;
using UnityEngine.EventSystems;
using View.Select;

public class RopeItem : BaseItem
{
    public GameObject LoseUI;
    [Header("旋转设置")]
    public float rotateSpeed = 90f;        // 旋转速度(度/秒)
    [Range(-180, 180)]
    public float minAngle ;          // 最小旋转角度(左)
    [Range(-180, 180)]
    public float maxAngle ;         // 最大旋转角度(右)
    private bool shouldRotateClockwise = false; // 当前旋转方向

    [Header("绳索设置")]
    public float extendSpeed = 5f;        // 伸出速度(单位/秒)
    public float maxLength = 10f;         // 最大长度
    public float hiddenRopeLength = 2f;   // 初始隐藏的绳子长度

    [Header("组件引用")]
    public Transform pivotPoint;          // 旋转支点(绳子顶部)
    public Transform hook;               // 吊钩物体
    public SpriteRenderer ropeRenderer;  // 一体式绳钩的渲染器

    private bool isRotating = true;
    private bool isExtending = false;
    private bool isRetracting = false;
    private float currentLength = 0f;
    private Vector2 extendDirection;
    private Vector3 initialHookPosition;
    private float initialRopeSize;
    [Header("点击隐藏物体设置")]
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    private int clickCount = 0;
    private void Start()
    {
        // 验证角度设置
        if (minAngle >= maxAngle)
        {
            Debug.LogError("最小角度必须小于最大角度！");
            minAngle = maxAngle - 1;
        }

        // 记录初始位置和尺寸
        initialHookPosition = hook.localPosition;
        if (ropeRenderer != null)
        {
            initialRopeSize = ropeRenderer.size.y;
        }

        // 初始隐藏部分绳子
        currentLength = hiddenRopeLength;
        UpdateRopeVisual();
    }

    private void Update()
    {
        if (isRotating)
        {
            HandleRotation();
        }
        else if (isExtending)
        {
            HandleExtending();
        }
        else if (isRetracting)
        {
            HandleRetracting();
        }
    }

    private void HandleRotation()
    {
        // 计算旋转方向
        float currentAngle = transform.eulerAngles.z;
        if (currentAngle > 180) currentAngle -= 360;

        // 检查是否需要改变旋转方向
        if (currentAngle <= minAngle)
        {
            shouldRotateClockwise = true;
        }
        else if (currentAngle >= maxAngle)
        {
            shouldRotateClockwise = false;
        }

        // 应用旋转
        float rotation = rotateSpeed * Time.deltaTime * (shouldRotateClockwise ? 1 : -1);
        transform.RotateAround(pivotPoint.position, Vector3.forward, rotation);
    }

    private void HandleExtending()
    {
        // 伸出吊钩
        currentLength += extendSpeed * Time.deltaTime;
        currentLength = Mathf.Min(currentLength, maxLength);

        UpdateRopeVisual();

        // 检查是否到达最大长度
        if (currentLength >= maxLength)
        {
            StartRetracting();
        }
    }

    private void HandleRetracting()
    {
        // 收回吊钩
        currentLength -= extendSpeed * Time.deltaTime;
        currentLength = Mathf.Max(currentLength, hiddenRopeLength);

        UpdateRopeVisual();

        // 检查是否完全收回
        if (currentLength <= hiddenRopeLength)
        {
            FinishRetracting();
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (clickCount < 3)
        {
            clickCount++;

            switch (clickCount)
            {
                case 1:
                    if (object1 != null) object1.SetActive(false);
                    break;
                case 2:
                    if (object2 != null) object2.SetActive(false);
                    break;
                case 3:
                    if (object3 != null) object3.SetActive(false);
                    break;
            }
        }

        if (isRotating && !isExtending && !isRetracting)
        {
            StopRotationAndExtend();
        }
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        // 可以添加鼠标悬停效果
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        // 可以取消鼠标悬停效果
    }

    private void StopRotationAndExtend()
    {
        isRotating = false;
        isExtending = true;

        // 计算伸出方向(当前旋转方向的向下向量)
        float angle = transform.eulerAngles.z * Mathf.Deg2Rad;
        extendDirection = new Vector2(Mathf.Sin(angle), -Mathf.Cos(angle));
    }

    private void StartRetracting()
    {
        isExtending = false;
        isRetracting = true;
    }

    private void FinishRetracting()
    {
        isRetracting = false;
        isRotating = true;

        // 如果点击次数用完并且未成功钓到（WinModel != 1），显示失败界面
        if (clickCount >= 3 && FishingModel.Instance.WinModel != 1)
        {
            if (LoseUI != null)
            {
                EndUI.DefeatUI(Resources.Load<Sprite>("Image/Defeat/Level6/Wrong"));
            }
        }
    }

    private void UpdateRopeVisual()
    {
        if (ropeRenderer == null) return;

        // 计算可见长度
        float visibleLength = Mathf.Max(0, currentLength - hiddenRopeLength);

        // 调整绳子精灵的尺寸
        ropeRenderer.size = new Vector2(ropeRenderer.size.x, initialRopeSize + visibleLength);

        // 调整吊钩位置
        if (hook != null)
        {
            hook.localPosition = initialHookPosition + (Vector3)(extendDirection * visibleLength);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (pivotPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pivotPoint.position, 0.2f);

        // 绘制角度限制
        Gizmos.color = Color.yellow;
        Vector3 minDir = Quaternion.Euler(0, 0, minAngle) * Vector3.down;
        Vector3 maxDir = Quaternion.Euler(0, 0, maxAngle) * Vector3.down;
        Gizmos.DrawLine(pivotPoint.position, pivotPoint.position + minDir * 2f);
        Gizmos.DrawLine(pivotPoint.position, pivotPoint.position + maxDir * 2f);

        // 绘制最大长度
        Gizmos.color = Color.green;
        Gizmos.DrawLine(pivotPoint.position, pivotPoint.position + Vector3.down * maxLength);
    }
}