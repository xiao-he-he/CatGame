
using UnityEngine;
using UnityEngine.SceneManagement;

public class fishingItem : MonoBehaviour
{
    public AudioClip clip;

    void OnTriggerEnter2D(Collider2D other)
    {
        AudioManage.Instant.PlayClip(clip);
        GameObject object3 = GameObject.FindGameObjectWithTag("Hook");
        if (other.gameObject == object3)
        {
            

            SceneManager.LoadScene("Level_6 1");
           
        }
    }

   
}
