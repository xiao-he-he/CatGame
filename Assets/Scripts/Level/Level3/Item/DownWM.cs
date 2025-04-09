using Level.Level3.Controll;
using UnityEngine.EventSystems;

namespace Level.Level3.Item
{
    public class DownWM:BaseItem
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            var c = _controller as Level3Controller;
            c.UseDownWM();
        }

        public override void OnPointerEnter(PointerEventData eventData) => throw new System.NotImplementedException();

        public override void OnPointerExit(PointerEventData eventData) => throw new System.NotImplementedException();
    }
}