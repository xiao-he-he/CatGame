using Level.Contronal;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Item
{
    public class Lamp:BaseItem
    {
        [RuntimeInitializeOnLoadMethod]
        static void DisableBurstVerification()
        {
            Unity.Burst.BurstCompiler.Options.EnableBurstCompileSynchronously = false;
            //Unity.Burst.BurstCompiler.Options.EnableSafetyChecks = false;
        }
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