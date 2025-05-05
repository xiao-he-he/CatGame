using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class MusicItem : BaseItem
{
   



    void Update()
    {
        
        transform.position += Vector3.down * 4f * Time.deltaTime;
        Debug.Log(Level6Model.Instance.MusicModel);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
       

        float y = transform.position.y;

       
        if (y <= 0.8f && y >= -0.8f)
        {
          
                 Level6Model.Instance.MusicModel++;
            Level6Model.Instance.MusicMode1 = 1;
               
           
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
