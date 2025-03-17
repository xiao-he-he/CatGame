using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingcatanimation : walkingcatdisappear
{
    [Header("������������")]
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;

    [Header("ʱ�����")]
    [Tooltip("�������ʱ��")]
    public float baseInterval = 0.5f;
    [Tooltip("�������ͣ��ʱ��")]
    public float finalStayDuration = 3f;

    void Update()
    {
        //��һ�׶Σ��������1�Ƿ���ʾ
        if (IsObject1Active())
        {
            if (!walkingcatdisappear.OnPointerClick()) 
            {
                StartCoroutine(SequenceRoutine());
            }
        }
    }

    IEnumerator SequenceRoutine()
    {
      
       
        yield return new WaitForSeconds(baseInterval);

        // �ڶ��׶Σ��л�����1->����2
        ToggleObject(object1, false);
        ToggleObject(object2, true);
        yield return new WaitForSeconds(baseInterval);

        // �����׶Σ��л�����2->����3
        ToggleObject(object2, false);
        ToggleObject(object3, true);
        yield return new WaitForSeconds(baseInterval);

        // ���Ľ׶Σ��л�����3->����4
        ToggleObject(object3, false);
        ToggleObject(object4, true);

        // ���ȴ�����������4
        yield return new WaitForSeconds(finalStayDuration);
        ToggleObject(object4, false);
    }

    public bool IsObject1Active()
    {
        return object1.activeSelf;
    }

        void ToggleObject(GameObject target, bool state)
    {
        if (target != null)
        {
            target.SetActive(state);
        }
       
    }
}
