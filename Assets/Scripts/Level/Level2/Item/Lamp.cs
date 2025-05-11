using Level.Contronal;
using Level.Level4.Item;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Item
{
    public class Lamp:BaseItem
    {
       
        public override void OnPointerClick(PointerEventData eventData)
        {
            
            var c = _controller as Level2Controller;
            c.ChangeLamp();
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
           
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
           
        }
    }
}