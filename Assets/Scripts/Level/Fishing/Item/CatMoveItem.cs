using UnityEngine;

public class CatMoveItem : MonoBehaviour
{
    [Header("移动设置")]
    public float moveSpeed = 4f;       // 移动速度(单位/秒)
    public float leftBoundX = -7.76f;     // 左边界X坐标
    public float rightBoundX = 7.76f;     // 右边界X坐标
    public float fixedZPosition = 0f;  // 固定的Z轴位置

    private bool movingRight = true;   // 当前移动方向
    private Vector3 currentPosition;   // 用于存储位置

    private void Start()
    {
        // 初始化时固定Z轴位置
        currentPosition = transform.position;
        currentPosition.z = fixedZPosition;
        transform.position = currentPosition;
    }

    private void Update()
    {
        // 获取当前位置并固定Z轴
        currentPosition = transform.position;
        currentPosition.z = fixedZPosition;

        // 根据当前方向移动（修正了direction计算错误）
        float direction = movingRight ? 1 : -1;
        currentPosition.x += direction * moveSpeed * Time.deltaTime;

        // 检查是否到达边界
        if (movingRight && currentPosition.x >= rightBoundX)
        {
            currentPosition.x = rightBoundX; // 确保不超出边界
            movingRight = false;
            FlipDirection();
        }
        else if (!movingRight && currentPosition.x <= leftBoundX)
        {
            currentPosition.x = leftBoundX; // 确保不超出边界
            movingRight = true;
            FlipDirection();
        }

        // 应用位置（确保Z轴固定）
        transform.position = currentPosition;
    }

    // 通过旋转Y轴改变朝向
    private void FlipDirection()
    {
        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x,
            movingRight ? 0 : 180,
            transform.rotation.eulerAngles.z
        );
    }

    // 可视化显示移动范围（修正了使用固定Z位置）
    private void OnDrawGizmosSelected()
    {
        Vector3 leftPos = new Vector3(leftBoundX, transform.position.y, fixedZPosition);
        Vector3 rightPos = new Vector3(rightBoundX, transform.position.y, fixedZPosition);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(leftPos, rightPos);
        Gizmos.DrawWireSphere(leftPos, 0.2f);
        Gizmos.DrawWireSphere(rightPos, 0.2f);
    }
}