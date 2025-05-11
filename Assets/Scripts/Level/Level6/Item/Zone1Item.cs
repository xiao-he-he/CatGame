using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone1Item : MonoBehaviour
{
  
    public GameObject object1;  // 需要被关闭显示的物体
    public GameObject object2;  // 需要被开启显示的物体
    public AudioClip clip1;
   
    public string triggerTag = "CatItemTag";  // 触发标签名称

    void OnTriggerEnter2D(Collider2D other)
    {
        AudioManage.Instant.PlayClip(clip1);
      GameObject object3 = GameObject.FindGameObjectWithTag(triggerTag);
        if ( other.gameObject == object3 )
        {
            Debug.Log("进入");
           
             object1.SetActive(false);
             object2.SetActive(true);
        }
    }
}
