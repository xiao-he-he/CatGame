using Level.Level3.Controll;
using UnityEngine.EventSystems;

namespace Level.Level3.Item
{
    public class Socket:BaseItem
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            var c = _controller as Level3Controller;
            c.UseE();
        }
        
    }
}