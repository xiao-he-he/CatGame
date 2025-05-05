using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeXiaoControll : MonoBehaviour
{
    public GameObject TeXiao1;
    public GameObject TeXiao2;
    public GameObject TeXiao3;
    public GameObject TeXiao4;
    void Update()
    {
        if(Level6Model.Instance.MusicMode1 == 1)
        {
            TeXiao1.SetActive(true);
            StartCoroutine(HideTargetAfterDelay1(0.3f));
        }
        if (Level6Model.Instance.MusicMode2 == 1)
        {
            TeXiao2.SetActive(true);
            StartCoroutine(HideTargetAfterDelay2(0.3f));
        }
        if (Level6Model.Instance.MusicMode3 == 1)
        {
            TeXiao3.SetActive(true);
            StartCoroutine(HideTargetAfterDelay3(0.3f));
        }
        if (Level6Model.Instance.MusicMode4 == 1)
        {
            TeXiao4.SetActive(true);
            StartCoroutine(HideTargetAfterDelay4(0.3f));
        }
        IEnumerator HideTargetAfterDelay1(float delay)
        {
            yield return new WaitForSeconds(delay);
          
                TeXiao1.SetActive(false);
            Level6Model.Instance.MusicMode1 = 0;    
            
        }
        IEnumerator HideTargetAfterDelay2(float delay)
        {
            yield return new WaitForSeconds(delay);

            TeXiao2.SetActive(false);
            Level6Model.Instance.MusicMode2 = 0;   

        }
        IEnumerator HideTargetAfterDelay3(float delay)
        {
            yield return new WaitForSeconds(delay);

            TeXiao3.SetActive(false);
            Level6Model.Instance.MusicMode3 = 0;

        }
        IEnumerator HideTargetAfterDelay4(float delay)
        {
            yield return new WaitForSeconds(delay);

            TeXiao4.SetActive(false);
            Level6Model.Instance.MusicMode4 = 0;

        }
    }
    public void restart()
    {
        SceneManager.LoadScene(7);
    }
    public void back()
    {
        SceneManager.LoadScene(0);
    }
}
