
using level1model;
using UnityEngine;
using UnityEngine.UI;
public class Level1TimeControll : MonoBehaviour
{
    public Text timeText;       // ������ʾʱ���Text���
    public Text catCountText;   // ������ʾè������Text���
    public float initialTime = 180f; // ��ʼʱ�䣨3����=180�룩
  

    void Start()
    {
        Time.timeScale = 0;
        // ��ʼ��ʣ��ʱ��
        Level1Model.Instance.Timing = initialTime;
    }

    void Update()
    { 

        // ���µ���ʱ
        UpdateCountdown();

        // ����ʱ����ʾ����ʽ��Ϊ����:���ӣ�
        UpdateTimeDisplay();

        // ����è������ʾ
        UpdateCatCountDisplay();
    }

    void UpdateCountdown()
    {
        // ֻ��ʱ��δ����ʱ����ʱ
        if (Level1Model.Instance.Timing > 0)
        {
            // ��ȥ֡ʱ��
            Level1Model.Instance.Timing -= Time.deltaTime;

            // ȷ��ʱ�䲻С��0
            Level1Model.Instance.Timing = Mathf.Max(0, Level1Model.Instance.Timing);

           
            // ��ѡ��ʱ�����ʱ�Ĵ���
            if (Level1Model.Instance.Timing <= 0)
            {
                TimeExpired();
            }
        }
    }

    void TimeExpired()
    {
        // ʱ�����ʱ���߼�
        Debug.Log("ʱ�䵽��");
        // ������������Ϸ�����������߼�
    }

    void UpdateTimeDisplay()
    {
        // ������Ӻ�����
        int minutes = Mathf.FloorToInt(Level1Model.Instance.Timing / 60f);
        int seconds = Mathf.FloorToInt(Level1Model.Instance.Timing % 60f);

        // ��ʽ��Ϊ��λ����ʾ����01:05��
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        // ����Text���
        if (timeText != null)
        {
            timeText.text = timeString;
        }
    }

    void UpdateCatCountDisplay()
    {
        if (catCountText != null)
        {
            // ��ʾè��������"15/20"��
            catCountText.text = Level1Model.Instance.CatModel + "/20";
        }
    }

    // ��ѡ�����ʱ��ķ���
    public void AddTime(float secondsToAdd)
    {
        Level1Model.Instance.Timing += secondsToAdd;
    }
}