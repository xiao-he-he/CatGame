using UnityEngine;

namespace View {
    public class GuideUI : MonoBehaviour
    {
        [Tooltip("教程UI")]
        public GameObject guide;

        void Start() {  // 关卡开始显示教程
            CheckGuide();
            OpenGuide();
        }

        void CheckGuide() {
            if (guide == null) {
                Debug.LogError("GuideUI: guide is null");
                return;
            }
        }

        public void OpenGuide() {
            CheckGuide();
            if (guide.activeSelf) {
                return;
            }

            guide.SetActive(true);

            // 暂停游戏
            Time.timeScale = 0;
        }
        
        public void CloseGuide() {
            CheckGuide();
            if (!guide.activeSelf) {
                return;
            }

            guide.SetActive(false);

            // 恢复游戏
            Time.timeScale = 1.0f;
        }
    }
}