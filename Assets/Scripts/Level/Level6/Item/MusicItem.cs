using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class MusicItem : BaseItem
{
    public AudioSource timerAudio;
    public float startY;       // 起点Y坐标
    public float endY;        // 终点Y坐标
    private bool movementStarted = false;
    private bool lerpCompleted = false;
    private float movementStartTime;
    public float TIME = 40f;
    private float fallSpeed;   // 计算出的下落速度
    private const float COOLDOWN_DURATION = 0.02f;
    private bool isOnCooldown = false;
    void Start()
    {
        transform.position = new Vector3(
            transform.position.x,
            startY,
            transform.position.z
        );
        // 计算固定速度：(距离)/时间
        fallSpeed = (startY - endY) / 1f; // 1秒移动时间
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
                // 第一阶段：Lerp移动
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
                // 第二阶段：匀速下落
                float newY = transform.position.y - fallSpeed * Time.deltaTime;
                transform.position = new Vector3(
                    transform.position.x,
                    newY,
                    transform.position.z
                );
            }

            // 检测D键按下
            if (!isOnCooldown && Input.GetKeyDown(KeyCode.S))
            {
                if (transform.position.y <= 1.2f && transform.position.y >= -1.2f)
                {

                    Level6Model.Instance.MusicModel++;
                    Level6Model.Instance.MusicMode1 = 1;
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


        if (y <= 1.2f && y >= -1.2f)
        {

            Level6Model.Instance.MusicModel++;
            Level6Model.Instance.MusicMode1 = 1;


            gameObject.SetActive(false);
        }

       

            if ((y <= 1.66f && y > 1.2f) || (y < -1.2f && y >= -2f))
            {
                gameObject.SetActive(false);
            Level6Model.Instance.MissMusic = 1;
        }
        IEnumerator CooldownCoroutine()
        {
            isOnCooldown = true; // 进入冷却状态
            yield return new WaitForSeconds(COOLDOWN_DURATION); // 等待冷却时间
            isOnCooldown = false; // 冷却结束
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
        isOnCooldown = true; // 进入冷却状态
        yield return new WaitForSeconds(COOLDOWN_DURATION); // 等待冷却时间
        isOnCooldown = false; // 冷却结束
    }
}
