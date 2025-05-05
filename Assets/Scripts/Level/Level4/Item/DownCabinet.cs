using Level.Level4.Controll;
using UnityEngine.EventSystems;

namespace Level.Level4.Item
{
    public class DownCabinet:BaseItem
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            ((Level4Controller)_controller).UseDownCabinet();
        }

        public override void OnPointerEnter(PointerEventData eventData) => throw new System.NotImplementedException();

        public override void OnPointerExit(PointerEventData eventData) => throw new System.NotImplementedException();
    }
}