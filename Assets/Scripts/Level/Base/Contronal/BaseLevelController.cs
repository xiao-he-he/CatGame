using System;
using Level.Model;
using UnityEngine;

namespace Level.Contronal
{
    public class BaseLevelController:MonoBehaviour
    {
        private static BaseLevelController _instance;
        public static BaseLevelController Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogError("没有挂载控制器");
                    return null;
                }
                else
                {
                    return _instance;
                }
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Debug.LogError("多挂载了控制器"+gameObject);
                Destroy(this);
            }
            
            
        }
    }
}