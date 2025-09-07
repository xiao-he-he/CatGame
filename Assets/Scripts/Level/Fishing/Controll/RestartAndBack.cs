
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartAndBack : MonoBehaviour
{
   
    public void ReStart()
    {
        SceneManager.LoadScene(7);
    }

    // Update is called once per frame
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
