using System.Collections;
using System.Collections.Generic;
using Level.Model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Pillow : BaseItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (Level2Model.Instance.IsOpenLight)
        {
            SceneManager.LoadScene("Level2-wakeup");
        }
    }
}
