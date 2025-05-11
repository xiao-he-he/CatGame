using UnityEngine;
using UnityEngine.EventSystems;
using View.Select;

public class RopeItem : BaseItem
{
    public AudioClip clip2;
    public GameObject LoseUI;
    [Header("��ת����")]
    public float rotateSpeed = 90f;        // ��ת�ٶ�(��/��)
    [Range(-180, 180)]
    public float minAngle ;          // ��С��ת�Ƕ�(��)
    [Range(-180, 180)]
    public float maxAngle ;         // �����ת�Ƕ�(��)
    private bool shouldRotateClockwise = false; // ��ǰ��ת����

    [Header("��������")]
    public float extendSpeed = 5f;        // ����ٶ�(��λ/��)
    public float maxLength = 10f;         // ��󳤶�
    public float hiddenRopeLength = 2f;   // ��ʼ���ص����ӳ���

    [Header("�������")]
    public Transform pivotPoint;          // ��ת֧��(���Ӷ���)
    public Transform hook;               // ��������
    public SpriteRenderer ropeRenderer;  // һ��ʽ��������Ⱦ��
    public AudioClip clip;
    private bool isRotating = true;
    private bool isExtending = false;
    private bool isRetracting = false;
    private float currentLength = 0f;
    private Vector2 extendDirection;
    private Vector3 initialHookPosition;
    private float initialRopeSize;
    [Header("���������������")]
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    private int clickCount = 0;
    private bool isPlay = false;
    private void Start()
    {
        // ��֤�Ƕ�����
        if (minAngle >= maxAngle)
        {
            Debug.LogError("��С�Ƕȱ���С�����Ƕȣ�");
            minAngle = maxAngle - 1;
        }

        // ��¼��ʼλ�úͳߴ�
        initialHookPosition = hook.localPosition;
        if (ropeRenderer != null)
        {
            initialRopeSize = ropeRenderer.size.y;
        }

        // ��ʼ���ز�������
        currentLength = hiddenRopeLength;
        UpdateRopeVisual();
    }

    private void Update()
    {
        if (isPlay == false)
        {
            AudioManage.Instant.PlayClip(clip, true);
            isPlay = true;
        }
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
        // ������ת����
        float currentAngle = transform.eulerAngles.z;
        if (currentAngle > 180) currentAngle -= 360;

        // ����Ƿ���Ҫ�ı���ת����
        if (currentAngle <= minAngle)
        {
            shouldRotateClockwise = true;
        }
        else if (currentAngle >= maxAngle)
        {
            shouldRotateClockwise = false;
        }

        // Ӧ����ת
        float rotation = rotateSpeed * Time.deltaTime * (shouldRotateClockwise ? 1 : -1);
        transform.RotateAround(pivotPoint.position, Vector3.forward, rotation);
    }

    private void HandleExtending()
    {
        // �������
        currentLength += extendSpeed * Time.deltaTime;
        currentLength = Mathf.Min(currentLength, maxLength);

        UpdateRopeVisual();

        // ����Ƿ񵽴���󳤶�
        if (currentLength >= maxLength)
        {
            StartRetracting();
        }
    }

    private void HandleRetracting()
    {
        // �ջص���
        currentLength -= extendSpeed * Time.deltaTime;
        currentLength = Mathf.Max(currentLength, hiddenRopeLength);

        UpdateRopeVisual();

        // ����Ƿ���ȫ�ջ�
        if (currentLength <= hiddenRopeLength)
        {
            FinishRetracting();
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        AudioManage.Instant.StopClip(clip);
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
        // �������������ͣЧ��
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        // ����ȡ�������ͣЧ��
    }

    private void StopRotationAndExtend()
    {
        isRotating = false;
        isExtending = true;

        // �����������(��ǰ��ת�������������)
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
        isPlay = false;
        AudioManage.Instant.PlayClip(clip2);
        // �������������겢��δ�ɹ�������WinModel != 1������ʾʧ�ܽ���
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

        // ����ɼ�����
        float visibleLength = Mathf.Max(0, currentLength - hiddenRopeLength);

        // �������Ӿ���ĳߴ�
        ropeRenderer.size = new Vector2(ropeRenderer.size.x, initialRopeSize + visibleLength);

        // ��������λ��
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

        // ���ƽǶ�����
        Gizmos.color = Color.yellow;
        Vector3 minDir = Quaternion.Euler(0, 0, minAngle) * Vector3.down;
        Vector3 maxDir = Quaternion.Euler(0, 0, maxAngle) * Vector3.down;
        Gizmos.DrawLine(pivotPoint.position, pivotPoint.position + minDir * 2f);
        Gizmos.DrawLine(pivotPoint.position, pivotPoint.position + maxDir * 2f);

        // ������󳤶�
        Gizmos.color = Color.green;
        Gizmos.DrawLine(pivotPoint.position, pivotPoint.position + Vector3.down * maxLength);
    }
}