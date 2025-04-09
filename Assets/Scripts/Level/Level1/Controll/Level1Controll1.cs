using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Level1Controll1 : MonoBehaviour
{
    private List<StageConfig> stages = new();

    void Start()
    {
        StartCoroutine(StageManager());
    }


    IEnumerator StageManager()
    {
        foreach (var stage in stages)
        {
            float stageTimer = 0;

            while (stageTimer < stage.duration)
            {
                // 等待间隔时间
                yield return new WaitForSeconds(5);

                // 随机选择对象
                List<GameObject> selected = GetRandomObjects(stage.objectsToShow);

                // 显示并隐藏对象
                StartCoroutine(ShowAndHide(selected, stage.visibleDuration));

                stageTimer += 5;
            }
        }
    }

    List<GameObject> GetRandomObjects(int count)
    {
        List<GameObject> candidates = new List<GameObject>();
        List<GameObject> selected = new List<GameObject>();

        for (int i = candidates.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            GameObject temp = candidates[i];
            candidates[i] = candidates[randomIndex];
            candidates[randomIndex] = temp;
        }

        for (int i = 0; i < Mathf.Min(count, candidates.Count); i++)
        {
            selected.Add(candidates[i]);
        }

        return selected;
    }

    IEnumerator ShowAndHide(List<GameObject> objects, float duration)
    {
        // 显示对象
        foreach (var obj in objects)
        {
            obj.SetActive(true);
        }

        // 等待持续时间
        yield return new WaitForSeconds(duration);

        // 隐藏对象
        foreach (var obj in objects)
        {
            obj.SetActive(false);
        }
    }


    [CreateAssetMenu]
    public class StageConfig : ScriptableObject
    {
        public float duration;
        public int objectsToShow;
        public float visibleDuration;

        public StageConfig(float dur, int count, float visible)
        {
            duration = dur;
            objectsToShow = count;
            visibleDuration = visible;
        }
    }
}

