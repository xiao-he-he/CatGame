using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardControll : MonoBehaviour
{
    public GameObject targetObject; // 在 Inspector 中指定要缩放的目标物体

    private float dCooldown = 0f;
    private float jCooldown = 0f;
    private float cooldownTime = 0.1f;

    void Update()
    {
        if (targetObject == null) return;

        if (dCooldown > 0)
            dCooldown -= Time.deltaTime;
        if (jCooldown > 0)
            jCooldown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.D) && dCooldown <= 0f)
        {
            ScaleX(targetObject, -0.02f);
            dCooldown = cooldownTime;
        }

        if (Input.GetKeyDown(KeyCode.J) && jCooldown <= 0f)
        {
            ScaleX(targetObject, -0.02f);
            jCooldown = cooldownTime;
        }
    }

    private void ScaleX(GameObject obj, float delta)
    {
        Vector3 scale = obj.transform.localScale;
        scale.x += delta;



        obj.transform.localScale = scale;
    }
}
