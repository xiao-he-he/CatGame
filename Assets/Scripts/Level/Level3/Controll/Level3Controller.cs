using Level.Contronal;
using Level.Level3.Model;
using UnityEngine;

namespace Level.Level3.Controll
{
    public class Level3Controller: BaseLevelController
    {
        private Level3Model _model = Level3Model.Instance;
        [SerializeField] private GameObject OpenE, CloseE;
        public GameObject WMUp,WMDown;

        public void CatMove(GameObject cat)
        {
            if (_model.DownIsOpen && _model.UpIsOpen)
            {
                if (_model.CatInUp)
                {
                    cat.transform.position -= new Vector3(0,4,0);
                }
                else
                {
                    cat.transform.position += new Vector3(0,4,0);
                }

                _model.CatInUp = !_model.CatInUp;
            }
        }

        public void UseUpDoor(GameObject door)
        {
            _model.UpIsOpen = !_model.UpIsOpen;
            if (_model.UpIsOpen)
            {
                door.transform.GetChild(0).gameObject.SetActive(false);
                door.transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("dad");
                door.transform.GetChild(1).gameObject.SetActive(false);
                door.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        
        public void UseDownDoor(GameObject door)
        {
            _model.DownIsOpen = !_model.DownIsOpen;
            if (_model.DownIsOpen)
            {
                door.transform.GetChild(0).gameObject.SetActive(false);
                door.transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                door.transform.GetChild(1).gameObject.SetActive(false);
                door.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        
        public void UseE()
        {
            _model.HasElectricity = !_model.HasElectricity;
            if (_model.HasElectricity)
            {
                CloseE.SetActive(false);
                OpenE.SetActive(true);
            }
            else
            {
                CloseE.SetActive(true);
                OpenE.SetActive(false);
                
                if (_model.UpIsUse)
                {
                    _model.UpIsUse = !_model.UpIsUse;
                    WMUp.SetActive(false);
                }
                if (_model.DownIsUes)
                {
                    WMDown.SetActive(false);
                    _model.DownIsUes = !_model.DownIsUes;
                }
            }
        }

        public void UseUpWM()
        {
            if (_model.HasElectricity)
            {
                _model.UpIsUse = !_model.UpIsUse;
                if (_model.UpIsUse)
                {
                    WMUp.SetActive(true);
                }
                else
                {
                    WMUp.SetActive(false);
                }
            }
        }
        
        public void UseDownWM()
        {
            if (_model.HasElectricity)
            {
                _model.DownIsUes = !_model.DownIsUes;
                if (_model.DownIsUes)
                {
                    WMDown.SetActive(true);
                }
                else
                {
                    WMDown.SetActive(false);
                }
            }
        }
    }
    
   
}