using Level.Level3.Controll;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Level.Level3.Item
{
    public class Cat:BaseItem
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            var c = _controller as Level3Controller;
            c.CatMove(gameObject);
            Debug.Log("wwwww");
        }

        public override void OnPointerEnter(PointerEventData eventData) => throw new System.NotImplementedException();

        public override void OnPointerExit(PointerEventData eventData) => throw new System.NotImplementedException();
    }
}