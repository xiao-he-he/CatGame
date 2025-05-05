using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fishingItem : MonoBehaviour
{
  
    public GameObject WinUI;
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject object3 = GameObject.FindGameObjectWithTag("Hook");
        if (other.gameObject == object3)
        {
            Debug.Log("½øÈë");
            
           WinUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Win()
    {
        SceneManager.LoadScene(0);
    }
   
}
