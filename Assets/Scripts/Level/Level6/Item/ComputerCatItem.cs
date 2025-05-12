using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using View.Select;

public class ComputerCatItem : BaseItem
{
    public GameObject musicstart;
    public AudioSource musicSource;
    public GameObject LoseUI;
    public GameObject ComCatItem;
    private bool isPlaying = false;
    public AudioClip clip;
    public bool isLose = false;

    public Text comboText; // ������ʾ Combo �� UI Text ���
    private void Start()
    {
        AudioManage.Instant.PlayClip(clip,true);
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (!isPlaying)
        {
            AudioManage.Instant.StopClip(clip);
            musicSource.Play();
            musicstart.SetActive(true);
            StartCoroutine(StopMusicAfterDelay(40f));
            isPlaying = true;
        }
    }

    private void Update()
    {
        if (Level6Model.Instance.MissMusic == 1)
        {
            Level6Model.Instance.MusicModel = 0;
            Level6Model.Instance.MissMusic = 0;
            UpdateComboDisplay(); // �������� Combo ��ʾ״̬
        }
        if (Level6Model.Instance.MusicModel >= 10)
        {
            musicstart.SetActive(false);
            gameObject.SetActive(false);
            ComCatItem.SetActive(true);
            musicSource.Pause();
            isPlaying = false;
            
        }

        // �������� Combo ��ʾ
        UpdateComboDisplay();
    }

    private IEnumerator StopMusicAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        
       
        if (Level6Model.Instance.MusicModel < 10&& isLose == false)
        {
            EndUI.DefeatUI(Resources.Load<Sprite>("Image/Defeat/Level6/Music"));
            musicSource.Pause();
            isPlaying = false;
            Level6Model.Instance.MusicModel = 0;
            UpdateComboDisplay(); // ���� Combo ��ʾ״̬
            isLose = true;
        }
        musicSource.Pause();
        isPlaying = false;
    }

    // ���� Combo ��ʾ
    void UpdateComboDisplay()
    {
        if (comboText != null)
        {
            // �� MusicModel ������ 0 ʱ��ʾ������ 0 ʱ����
            bool shouldShow = Level6Model.Instance.MusicModel != 0;
            comboText.gameObject.SetActive(shouldShow);

            if (shouldShow)
            {
                comboText.text = "Combo X" + Level6Model.Instance.MusicModel;
            }
        }
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        // ����ԭ���߼�
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        // ����ԭ���߼�
    }
}