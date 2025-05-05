using Level.Level4.Controll;
using UnityEngine.EventSystems;

namespace Level.Level4.Item
{
    public class PotCat:BaseItem
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            var c = _controller as  Level4Controller;
            c.CheckCat();
        }
        
    }
}