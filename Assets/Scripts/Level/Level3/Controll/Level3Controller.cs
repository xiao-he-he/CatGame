using Cysharp.Threading.Tasks;
using Level.Contronal;
using Level.Level3.Model;
using UnityEngine;
using View;
using EndUI = View.Select.EndUI;

namespace Level.Level3.Controll
{
    public class Level3Controller: BaseLevelController
    {
        private Level3Model _model = Level3Model.Instance;
        [SerializeField] private GameObject OpenE, CloseE;
        public GameObject WMUp,WMDown;
        public GameObject cat,CatRun;

        public async void CatMove()
        {
            if (_model.DownIsOpen && _model.UpIsOpen)
            {
                CatRun.SetActive(true);
                cat.SetActive(false);
                await UniTask.WaitForSeconds(0.1f);
                if (_model.CatInUp)
                {
                    cat.transform.position -= new Vector3(0,4,0);
                }
                else
                {
                    cat.transform.position += new Vector3(0,4,0);
                }
                _model.CatInUp = !_model.CatInUp;
                CatRun.SetActive(false);
                cat.SetActive(true);
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

        public async void UseUpWM()
        {
            if (_model.HasElectricity)
            {
                _model.UpIsUse = !_model.UpIsUse;
                if (_model.UpIsUse)
                {
                    WMUp.SetActive(true);
                    
                    if (!_model.UpIsOpen)
                    {
                        await UniTask.WaitForSeconds(0.5f);
                        EndUI.DefeatUI(Resources.Load<Sprite>("Image/Defeat/Level3D"));
                        return;
                    }
                    if (_model.DownIsUes||!_model.DownIsOpen)
                    {
                        await UniTask.WaitForSeconds(0.5f);
                        EndUI.WinUI(Resources.Load<Sprite>("Image/Win/Level3S"));
                    }
                    else if(_model.CatInUp)
                    {
                        CatMove();
                    }
                }
                else
                {
                    WMUp.SetActive(false);
                }
            }
        }
        
        public async void UseDownWM()
        {
            if (_model.HasElectricity)
            {
                _model.DownIsUes = !_model.DownIsUes;
                if (_model.DownIsUes)
                {
                    WMDown.SetActive(true);
                    if (!_model.DownIsOpen)
                    {
                        await UniTask.WaitForSeconds(0.5f);
                        EndUI.DefeatUI(Resources.Load<Sprite>("Image/Defeat/Level3D"));
                        return;
                    }
                    if (_model.UpIsUse||!_model.UpIsOpen)
                    {
                        await UniTask.WaitForSeconds(0.5f);
                        EndUI.WinUI(Resources.Load<Sprite>("Image/Win/Level3S"));
                    }
                    else if(!_model.CatInUp)
                    {
                        CatMove();
                    }
                }
                else
                {
                    WMDown.SetActive(false);
                }
            }
        }
    }
    
   
}