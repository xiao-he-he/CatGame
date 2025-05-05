using Level.Contronal;
using Level.Level4.Model;
using UnityEngine;

namespace Level.Level4.Controll
{
    public class Level4Controller:BaseLevelController
    {
        private Level4Model _model = Level4Model.Instance;
        public GameObject PingPotCover,Cat;
        public GameObject CatWant,CatDream;
        public GameObject FireDown, FireUp;
        public GameObject GZup, GZdown;
        public GameObject GZLeft,leftOpen, GZRight,rightopen;
        public GameObject Water;
        public GameObject Pot_1,pot_2,pot_3;
        public void OpenPingPot()
        {
            PingPotCover.SetActive(false);
            Cat.SetActive(true);
            _model.OpenPingPot = true;
        }

        public void CheckCat()
        {
            CatWant.SetActive(false);
            CatDream.SetActive(true);
        }

        public void OpenUpFire()
        {
            _model.OpenFireUp = !_model.OpenFireUp;
            FireUp.SetActive(_model.OpenFireUp);
        }

        public void OpenDownFire()
        {
            _model.OpenFireDown = !_model.OpenFireDown;
            FireDown.SetActive(_model.OpenFireDown);
        }

        public void UseUpCabinet()
        {
            _model.OpenUpCabinet = !_model.OpenUpCabinet;
            GZup.SetActive(_model.OpenUpCabinet);
        }
        
        public void UseDownCabinet()
        {
            _model.OpenDownCabinet = !_model.OpenDownCabinet;
            GZdown.SetActive(_model.OpenDownCabinet);
        }
        public void UseLeftCabinet()
        {
            _model.OpenLeftCabinet = !_model.OpenLeftCabinet;
            GZLeft.SetActive(_model.OpenLeftCabinet);
            leftOpen.SetActive(!_model.OpenLeftCabinet);
        }
        
        public void UseRightCabinet()
        {
            _model.OpenRightCabinet = !_model.OpenRightCabinet;
            GZRight.SetActive(_model.OpenRightCabinet);
            rightopen.SetActive(!_model.OpenRightCabinet);
        }

        public void SwitchWater()
        {
            _model.OpenWater = !_model.OpenWater;
            Water.SetActive(_model.OpenWater);
        }

        public void MovePot()
        {
            if (_model.PotPos == 1)
            {
                Pot_1.SetActive(false);
                pot_2.SetActive(true);
                _model.PotPos++;
            }
            else if(_model.PotPos == 2)
            {
                pot_2.SetActive(false);
                pot_3.SetActive(true);
                _model.PotPos++;
            }
            else
            {
                pot_2.SetActive(true);
                pot_3.SetActive(false);
                _model.PotPos--;
            }
           
        }
    }
}