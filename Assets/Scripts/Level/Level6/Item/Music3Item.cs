using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Music3Item :BaseItem
{




    void Update()
    {

        transform.position += Vector3.down * 4f * Time.deltaTime;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {


        float y = transform.position.y;


        if (y <= 0.8f && y >= -0.8f)
        {

            Level6Model.Instance.MusicModel++;
            Level6Model.Instance.MusicMode3 = 1;


            gameObject.SetActive(false);
        }

        else if ((y <= 1.66f && y > 0.8f) || (y < -0.8f && y >= -2f))
        {
            gameObject.SetActive(false);
        }




    }



    public override void OnPointerEnter(PointerEventData eventData)
    {

    }

    public override void OnPointerExit(PointerEventData eventData)
    {
    }
}
