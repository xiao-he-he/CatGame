using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YiGuiCtaItem : MonoBehaviour
{
    public string triggerTag = "DouMaoBang";  // ´¥·¢±êÇ©Ãû³Æ

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject object3 = GameObject.FindGameObjectWithTag(triggerTag);
        if (other.gameObject == object3)
        {
            SceneManager.LoadScene("Level6-fishing");       
        }
    }
}
