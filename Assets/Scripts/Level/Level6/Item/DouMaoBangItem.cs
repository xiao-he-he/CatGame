using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DouMaoBangItem : Level5BaseItem
{
    private bool isDragging = false;
    private Vector3 offset;
    private Collider2D targetArea;
    private bool isInTargetArea = false;
    private float fixedZPosition; // ?›¥?????Z????


    public GameObject targetZone;
    private Vector3 initialPosition;

    private void Start()
    {
        fixedZPosition = transform.position.z; // ??????????Z????
        initialPosition = transform.position;  // ??????¦Ë??

        if (targetZone != null)
        {
            targetArea = targetZone.GetComponent<Collider2D>();

            if (targetArea == null)
            {
                Debug.LogError("?????????? Collider2D ?????");
            }
        }
        else
        {
            Debug.LogError("targetZone ¦Ä?????");
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        // ??????
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        // ?????????
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        // ????????
    }

    protected override void OnHold(float HoldTime)
    {
        if (!isDragging)
        {
            isDragging = true;
            // ??????¦Ë?¨°????Z????
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = fixedZPosition;
            offset = transform.position - mousePosition;
        }
    }

    private void Update()
    {
        if (isDragging)
        {
            // ??????¦Ë?¨°????Z????
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
            Debug.Log("¦Ä??????????????¦Ë?¨¢?");
            transform.position = initialPosition;

          
           
        }
    }

}
