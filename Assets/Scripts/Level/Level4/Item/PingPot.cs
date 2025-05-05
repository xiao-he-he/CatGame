using Level.Level3.Controll;
using Level.Level4.Controll;
using Level.Level4.Model;
using UnityEngine.EventSystems;

namespace Level.Level4.Item
{
    public class PingPot:BaseItem
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            var c = _controller as  Level4Controller;
            c.OpenPingPot();
        }
        
    }
}