using UnityEngine;

public class CatMoveItem : MonoBehaviour
{
    [Header("移动设置")]
    public float moveSpeed = 4f;
    public float leftBoundX = -7.76f;
    public float rightBoundX = 7.76f;
    public float fixedZPosition = 0f;
    public float acceleration = 0.5f;
    public float maxSpeed = 10f;

    private bool movingRight = true;
    private Vector3 currentPosition;
    private float currentMoveSpeed;
   
    private void Start()
    {
        currentPosition = transform.position;
        currentPosition.z = fixedZPosition;
        transform.position = currentPosition;
        currentMoveSpeed = moveSpeed;
    }

    private void Update()
    {
        currentPosition = transform.position;
        currentPosition.z = fixedZPosition;

        // 1. 先计算速度（不考虑方向）
        currentMoveSpeed = Mathf.Clamp(
            Mathf.Abs(currentMoveSpeed) + acceleration * Time.deltaTime,
            0,
            maxSpeed
        );

        // 2. 应用方向
        float moveDirection = movingRight ? 1 : -1;
        currentPosition.x += moveDirection * currentMoveSpeed * Time.deltaTime;

        // 3. 边界检查（先移动再修正）
        if (currentPosition.x > rightBoundX)
        {
            currentPosition.x = rightBoundX;
            ChangeDirection(false);
        }
        else if (currentPosition.x < leftBoundX)
        {
            currentPosition.x = leftBoundX;
            ChangeDirection(true);
        }

        transform.position = currentPosition;
    }

    private void ChangeDirection(bool newRightDirection)
    {
        if (movingRight == newRightDirection) return;

        movingRight = newRightDirection;
        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x,
            movingRight ? 0 : 180,
            transform.rotation.eulerAngles.z
        );
        // 转向时速度立即反向
        currentMoveSpeed *= -1;
    }

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