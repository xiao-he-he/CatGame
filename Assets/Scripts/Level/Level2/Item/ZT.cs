using Level.Contronal;
using UnityEngine.EventSystems;

namespace Item
{
    public class ZT:BaseItem
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            ((Level2Controller)_controller).ChackCat();
        }
        
    }
}