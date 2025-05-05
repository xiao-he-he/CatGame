using Level.Level4.Controll;
using Level.Level4.Model;
using UnityEngine.EventSystems;

namespace Level.Level4.Item
{
    public class CabinetCan:BaseItem
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            ((Level4Controller)_controller).PutCan();
        }
        
    }
}