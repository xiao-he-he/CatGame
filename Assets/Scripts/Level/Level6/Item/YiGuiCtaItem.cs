
using UnityEngine;
using UnityEngine.SceneManagement;

public class YiGuiCtaItem : MonoBehaviour
{
    public string triggerTag = "DouMaoBang";  // ������ǩ����

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject object3 = GameObject.FindGameObjectWithTag(triggerTag);
        if (other.gameObject == object3)
        {
            SceneManager.LoadScene("Level6-fishing");       
        }
    }
}
