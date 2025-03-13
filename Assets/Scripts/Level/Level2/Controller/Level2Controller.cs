using System;
using System.Collections.Generic;
using System.Linq;
using Level.Model;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Level.Contronal
{
    public class Level2Controller : BaseLevelController
    {
        public Light2D levellamp;
        public Light2D levellight;
        
        
        private Level2Model _model;
        private void Start()
        {
            _model = new Level2Model();
        }

        public void ChangeLight()
        {
            _model.IsOpenLight = !_model.IsOpenLight;
            if (_model.IsOpenLight)
            {
                Debug.LogWarning("开灯");
                levellight.intensity = 1;
                if (_model.IsOpenLamp)
                {
                    levellamp.intensity = 1.2f;
                }
                else
                {
                    levellamp.intensity = 0.6f;
                }
            }
            else
            {
                Debug.LogWarning("关灯");
                levellight.intensity = 0.2f;
                if (_model.IsOpenLamp)
                {
                    levellamp.intensity = 0.8f;
                }
                else
                {
                    levellamp.intensity = 0.2f;
                }
            }
        }
        
        public void ChangeLamp()
        {
            _model.IsOpenLamp = !_model.IsOpenLamp;
            if (_model.IsOpenLamp)
            {
                levellamp.intensity = 1.2f;
            }
            else
            {
                if (!_model.IsOpenLight)
                {
                    levellamp.intensity = 0.2f;
                    Debug.LogWarning("Light是关着的");
                }
                else
                {
                    levellamp.intensity = 0.8f;
                    Debug.LogWarning("Light是开着的");
                }
                    
            }
        }

        public void ChackCat()
        {
            if (_model.IsOpenLight && _model.IsOpenLamp)
            {
                //开始游戏的逻辑
                return;
            }
            Debug.LogWarning("还没有开所有的灯");
        }
        
    }
}