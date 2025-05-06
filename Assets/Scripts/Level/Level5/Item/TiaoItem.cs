using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiaoItem : MonoBehaviour
{
    [Header("旋转设置")]
    public Transform pivotPoint;      // 支点空物体
    public float rotationSpeed = 30f; // 旋转速度(度/秒)
    public float minAngle = -45f;     // 最小旋转角度
    public float maxAngle = 45f;      // 最大旋转角度
    
    public Vector3 rotationAxis = Vector3.up; // 旋转轴

    [Header("调试")]
    public bool isRotating = true;    // 控制旋转开关
    [SerializeField] private float currentAngle = 0f; // 当前角度

    private int direction = 1;        // 1表示正向旋转，-1表示反向
    private float pauseTimer = 0f;
    private bool isPausing = false;
    public GameObject moon;
    public GameObject sun;
    public GameObject blood1;
    public GameObject blood2;   
    public GameObject blood3;
    public GameObject blood4;
    public GameObject chou;


    void Start()
    {
        // 初始化当前角度为起始角度
        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);
    }

    void Update()
    {
        if (!isRotating || pivotPoint == null) return;

        if (isPausing)
        {
            pauseTimer -= Time.deltaTime;
            if (pauseTimer <= 0f)
            {
                isPausing = false;
                direction *= -1;  // 反转旋转方向
            }
            return;
        }

        // 计算这一帧的旋转量
        float rotationAmount = rotationSpeed * Time.deltaTime * direction;
        currentAngle += rotationAmount;

        // 检查是否超出角度限制
        if (direction > 0 && currentAngle >= maxAngle)
        {
            currentAngle = maxAngle;
            StartPause();
        }
        else if (direction < 0 && currentAngle <= minAngle)
        {
            currentAngle = minAngle;
            StartPause();
        }

        // 应用旋转
        transform.RotateAround(pivotPoint.position, rotationAxis, rotationAmount);
    }

    void StartPause()
    {
        isPausing = true;
      
    }

    // 在编辑器中可视化支点和旋转范围
    void OnDrawGizmosSelected()
    {
        if (pivotPoint != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(pivotPoint.position, 0.1f);
            Gizmos.DrawLine(pivotPoint.position, transform.position);

            Gizmos.color = Color.green;
            DrawRotationArc(rotationAxis, minAngle, maxAngle);
        }
    }

    void DrawRotationArc(Vector3 axis, float min, float max)
    {
        Vector3 startDir = Quaternion.AngleAxis(min, axis) * (transform.position - pivotPoint.position);
        Vector3 endDir = Quaternion.AngleAxis(max, axis) * (transform.position - pivotPoint.position);

        // 绘制弧线
        int segments = 30;
        float angleStep = (max - min) / segments;
        Vector3 prevPoint = pivotPoint.position + startDir;

        for (int i = 1; i <= segments; i++)
        {
            float angle = min + angleStep * i;
            Vector3 nextPoint = pivotPoint.position + Quaternion.AngleAxis(angle, axis) * (transform.position - pivotPoint.position);
            Gizmos.DrawLine(prevPoint, nextPoint);
            prevPoint = nextPoint;
        }

        // 绘制最小/最大角度标记
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pivotPoint.position, pivotPoint.position + startDir * 1.2f);
        Gizmos.DrawLine(pivotPoint.position, pivotPoint.position + endDir * 1.2f);
    }
    public void Stop()
    {
        
        if(currentAngle > 0)
        {
            moon.SetActive(true);
            sun.SetActive(false);
            blood1.SetActive(false);
            blood2.SetActive(false);
            blood3.SetActive(false);
            blood4.SetActive(false);
            chou.SetActive(false);
        }
        else
        {
            moon.SetActive(false);
            sun.SetActive(true);
            blood1.SetActive(true);
            blood2.SetActive(true);
            blood3.SetActive(true);
            blood4.SetActive(true);
            chou.SetActive(false);
        }
    }
}
