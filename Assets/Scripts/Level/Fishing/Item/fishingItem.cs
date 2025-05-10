
using UnityEngine;
using UnityEngine.SceneManagement;

public class fishingItem : MonoBehaviour
{
  
   
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject object3 = GameObject.FindGameObjectWithTag("Hook");
        if (other.gameObject == object3)
        {
            Debug.Log("����");

            SceneManager.LoadScene("Level_6 1");
           
        }
    }

   
}
