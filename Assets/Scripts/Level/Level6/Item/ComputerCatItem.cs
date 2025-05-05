using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ComputerCatItem : BaseItem
{
    public GameObject musicstart;
    public AudioSource musicSource;
    public GameObject LoseUI;
    public GameObject ComCatItem;
    private bool isPlaying = false;

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (!isPlaying)
        {
            musicSource.Play();
            musicstart.SetActive(true);
            StartCoroutine(StopMusicAfterDelay(42f));
            isPlaying = true;
        }
    }

    private IEnumerator StopMusicAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (Level6Model.Instance.MusicModel > 40)
        {
            musicstart.SetActive(false); 
            gameObject.SetActive(false);
            ComCatItem.SetActive(true);
        }
        else
        {
            LoseUI.SetActive(true);
            musicSource.Pause();
            isPlaying = false;
            Time.timeScale = 0f;
            Level6Model.Instance.MusicModel = 0;
            
        }
        musicSource.Pause();

        isPlaying = false;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
       
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        
    }
}