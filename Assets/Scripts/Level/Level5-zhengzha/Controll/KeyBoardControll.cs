using System.Collections;
using UnityEngine;

public class KeyBoardControll : MonoBehaviour
{
    public GameObject targetObject; // 在 Inspector 中指定要缩放的目标物体

    [Header("动画控制")]
    public Animator leftKeyAnimator;   // 左键控制的Animator (A/左箭头)
    public string leftKeyAnimation1 = "Animation1"; // 左键按下动画
    public string leftKeyAnimation2 = "Animation3"; // 左键释放动画
    public Animator rightKeyAnimator;  // 右键控制的Animator (D/右箭头)
    public string rightKeyAnimation1 = "Animation2"; // 右键按下动画
    public string rightKeyAnimation2 = "Animation4"; // 右键释放动画

    private float leftCooldown = 0f;
    private float rightCooldown = 0f;
    private float cooldownTime = 0.1f;

    void Update()
    {
        if (targetObject == null) return;

        // 冷却时间更新
        if (leftCooldown > 0)
            leftCooldown -= Time.deltaTime;
        if (rightCooldown > 0)
            rightCooldown -= Time.deltaTime;

        // 左键处理 (A键或左箭头)
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) )&& leftCooldown <= 0f)
        {
            ScaleX(targetObject, -0.02f);
            leftKeyAnimator.SetTrigger(leftKeyAnimation1);
            leftCooldown = cooldownTime;
            StartCoroutine(TriggerDelayedAnimation(leftKeyAnimator, leftKeyAnimation2));
        }

        // 右键处理 (D键或右箭头)
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && rightCooldown <= 0f)
        {
            ScaleX(targetObject, -0.02f);
            rightKeyAnimator.SetTrigger(rightKeyAnimation1);
            rightCooldown = cooldownTime;
            StartCoroutine(TriggerDelayedAnimation(rightKeyAnimator, rightKeyAnimation2));
        }
    }

    private void ScaleX(GameObject obj, float delta)
    {
        Vector3 scale = obj.transform.localScale;
        scale.x += delta;
        obj.transform.localScale = scale;
    }

    IEnumerator TriggerDelayedAnimation(Animator animator, string triggerName)
    {
        yield return new WaitForSeconds(0.01f);
        animator.SetTrigger(triggerName);
    }
}