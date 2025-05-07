using System.Collections;
using System.Collections.Generic;
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

    // Combo 显示相关变量
    public Text comboText; // 用于显示 Combo 的 UI Text 组件

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (!isPlaying)
        {
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
            UpdateComboDisplay(); // 立即更新 Combo 显示状态
        }
        if (Level6Model.Instance.MusicModel >= 10)
        {
            musicstart.SetActive(false);
            gameObject.SetActive(false);
            ComCatItem.SetActive(true);
            musicSource.Pause();
            isPlaying = false;
        }

        // 持续更新 Combo 显示
        UpdateComboDisplay();
    }

    private IEnumerator StopMusicAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        
       
        if (Level6Model.Instance.MusicModel < 10)
        {
            EndUI.DefeatUI(Resources.Load<Sprite>("Image/Defeat/Level6/Music"));
            musicSource.Pause();
            isPlaying = false;
            Time.timeScale = 0f;
            Level6Model.Instance.MusicModel = 0;
            UpdateComboDisplay(); // 更新 Combo 显示状态
        }
        musicSource.Pause();
        isPlaying = false;
    }

    // 更新 Combo 显示
    void UpdateComboDisplay()
    {
        if (comboText != null)
        {
            // 当 MusicModel 不等于 0 时显示，等于 0 时隐藏
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
        // 保留原有逻辑
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        // 保留原有逻辑
    }
}