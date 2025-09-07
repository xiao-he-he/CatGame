using UnityEngine;
using UnityEngine.EventSystems;
using View.Select;

public class ItemCatItem : Level5BaseItem
{
    private bool isDragging = false;
    private Vector3 offset;
    private Collider2D targetArea;
    private bool isInTargetArea = false;
    private float fixedZPosition; // �洢�̶���Z����
    public GameObject DouMaoBang;
    public GameObject LoseUI;
    public GameObject targetZone;
    public AudioClip clip;
  
    private void Start()
    {
        fixedZPosition = transform.position.z; // ��ʼ��ʱ����Z����
        
        if (targetZone != null)
        {
            targetArea = targetZone.GetComponent<Collider2D>();
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        // ����߼�
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        // �������߼�
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        // ����뿪�߼�
    }

    protected override void OnHold(float HoldTime)
    {
        if (!isDragging)
        {
            AudioManage.Instant.PlayClip(clip);
            isDragging = true;
            // ��ȡ���λ�ò��̶�Z����
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = fixedZPosition;
            offset = transform.position - mousePosition;
        }
    }

    private void Update()
    {
        if (isDragging)
        {
            // ��ȡ���λ�ò��̶�Z����
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
            gameObject.SetActive(false);

            DouMaoBang.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
            EndUI.DefeatUI(Resources.Load<Sprite>("Image/Defeat/Level6/Wrong"));
        }
    }
}