using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Music3Item :BaseItem
{
    public AudioSource timerAudio;
    public float startY;       // ���Y����
    public float endY;        // �յ�Y����
    private bool movementStarted = false;
    private bool lerpCompleted = false;
    private float movementStartTime;
    public float TIME = 40f;
    private float fallSpeed;   // ������������ٶ�
    private const float COOLDOWN_DURATION = 0.02f;
    private bool isOnCooldown = false;
    void Start()
    {
        transform.position = new Vector3(
            transform.position.x,
            startY,
            transform.position.z
        );
        // ����̶��ٶȣ�(����)/ʱ��
        fallSpeed = (startY - endY) / 1f; // 1���ƶ�ʱ��
    }

    void Update()
    {
        if (!movementStarted && timerAudio.time >= TIME - 2f)
        {
            movementStarted = true;
            movementStartTime = timerAudio.time;
        }

        if (movementStarted)
        {
            if (!lerpCompleted)
            {
                // ��һ�׶Σ�Lerp�ƶ�
                float progress = Mathf.Clamp01((timerAudio.time - movementStartTime) / 2f);
                float newY = Mathf.Lerp(startY, endY, progress);
                transform.position = new Vector3(
                    transform.position.x,
                    newY,
                    transform.position.z
                );

                if (progress >= 1f)
                {
                    lerpCompleted = true;
                }
            }
            else
            {
                // �ڶ��׶Σ���������
                float newY = transform.position.y - fallSpeed * Time.deltaTime;
                transform.position = new Vector3(
                    transform.position.x,
                    newY,
                    transform.position.z
                );
            }
            if (!isOnCooldown && Input.GetKeyDown(KeyCode.J))
            {
                if (transform.position.y <= 0.8f && transform.position.y >= -0.8f)
                {

                    Level6Model.Instance.MusicModel++;
                    Level6Model.Instance.MusicMode3 = 1;
                    StartCoroutine(CooldownCoroutine());

                    gameObject.SetActive(false);
                }

            }
            if (transform.position.y < -2f)
            {
                Level6Model.Instance.MissMusic = 1;
                gameObject.SetActive(false);
            }
        }
    }
    public override void OnPointerClick(PointerEventData eventData)
    {


        float y = transform.position.y;


        if (y <= 0.8f && y >= -0.8f)
        {

            Level6Model.Instance.MusicModel++;
            Level6Model.Instance.MusicMode3 = 1;
            Debug.Log("1");

            gameObject.SetActive(false);
        }

        else if ((y <= 1.66f && y > 0.8f) || (y < -0.8f && y >= -2f))
        {
            gameObject.SetActive(false);
            Level6Model.Instance.MissMusic = 1;
        }




    }



    public override void OnPointerEnter(PointerEventData eventData)
    {

    }

    public override void OnPointerExit(PointerEventData eventData)
    {
    }
    IEnumerator CooldownCoroutine()
    {
        isOnCooldown = true; // ������ȴ״̬
        yield return new WaitForSeconds(COOLDOWN_DURATION); // �ȴ���ȴʱ��
        isOnCooldown = false; // ��ȴ����
    }
}
