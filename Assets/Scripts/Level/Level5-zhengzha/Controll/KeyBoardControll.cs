using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardControll : MonoBehaviour
{
    public GameObject targetObject; // 在 Inspector 中指定要缩放的目标物体

    [Header("动画控制")]
    public Animator dKeyAnimator;   // D键控制的Animator
    public string dKeyAnimation = "Animation1"; // D键播放的动画名称
    public Animator jKeyAnimator;   // J键控制的Animator
    public string jKeyAnimation = "Animation2"; // J键播放的动画名称

    private float dCooldown = 0f;
    private float jCooldown = 0f;
    private float cooldownTime = 0.1f;

    void Update()
    {
        if (targetObject == null) return;

        // 冷却时间更新
        if (dCooldown > 0)
            dCooldown -= Time.deltaTime;
        if (jCooldown > 0)
            jCooldown -= Time.deltaTime;

        // D键处理
        if (Input.GetKeyDown(KeyCode.D) && dCooldown <= 0f)
        {
            ScaleX(targetObject, -0.02f);
            dKeyAnimator.SetTrigger("Animation1");
            dCooldown = cooldownTime;
            Delay();
            dKeyAnimator.SetTrigger("Animation3");
        }

        // J键处理
        if (Input.GetKeyDown(KeyCode.J) && jCooldown <= 0f)
        {
            ScaleX(targetObject, -0.02f);
            jKeyAnimator.SetTrigger("Animation2");
            jCooldown = cooldownTime;
            Delay();
            jKeyAnimator.SetTrigger("Animation4");
        }
    }

    private void ScaleX(GameObject obj, float delta)
    {
        Vector3 scale = obj.transform.localScale;
        scale.x += delta;
        obj.transform.localScale = scale;
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.01f);
    }

}