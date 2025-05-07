using UnityEngine;
using UnityEngine.UI;

namespace View.Select
{
    public static class EndUI
    {
        public static void WinUI(Sprite Image)
        {
            if (Image == null)
            {
                Debug.LogError("Image不能为空");
                return;
            }
            Transform root = GameObject.Instantiate(Resources.Load<GameObject>("Prefab/View/Root")).transform;
            var g = GameObject.Instantiate(Resources.Load<GameObject>("Prefab/View/Win"),root);
            g.transform.GetChild(0).GetComponent<Image>().sprite = Image;
        }

        public static void DefeatUI(Sprite Image)
        {
            if (Image == null)
            {
                Debug.LogError("Image不能为空");
                return;
            }
            Transform root = GameObject.Instantiate(Resources.Load<GameObject>("Prefab/View/Root")).transform;
            var g = GameObject.Instantiate(Resources.Load<GameObject>("Prefab/View/Lose (1)"),root);
            g.transform.GetChild(0).GetComponent<Image>().sprite = Image;
            Debug.Log(g.name);
        }
    }
}