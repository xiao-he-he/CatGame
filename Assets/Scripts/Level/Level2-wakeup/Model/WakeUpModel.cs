using System.Collections;
using System.Collections.Generic;
using Level.Model;
using UnityEngine;
namespace wakeupmodel
{ 
    public class WakeUpModel : BaseLevelModel<WakeUpModel>
    {
        public float clickModel = 0f;
        public float FrequencyTime = 0f;
        public float FrequencyRange = 2f;
        public float AngryTime = 0f;
        public float SleepTime = 0f;
        public float ComfotableTime = 0f;
        public float GetFrequency()
        {
            if (FrequencyTime > 0f) // ∑¿÷π≥˝“‘¡„
            {
                return clickModel / FrequencyTime;
            }
            return 0f;
        }
    }
}
