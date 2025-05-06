using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fishingItem : MonoBehaviour
{
  
   
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject object3 = GameObject.FindGameObjectWithTag("Hook");
        if (other.gameObject == object3)
        {
            Debug.Log("½øÈë");

            SceneManager.LoadScene(9);
            Time.timeScale = 0f;
        }
    }

    public void Win()
    {
        SceneManager.LoadScene(0);
    }
   
}
