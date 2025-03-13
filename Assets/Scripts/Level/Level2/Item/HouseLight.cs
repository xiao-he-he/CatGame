using Level.Contronal;
using UnityEngine.EventSystems;

namespace Item
{
    public class HouseLight:BaseItem
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            var c = _controller as Level2Controller;
            c.ChangeLight();
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            
        }
    }
}