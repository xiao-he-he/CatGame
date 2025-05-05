using System;
using Level.Contronal;
using Level.Level4.Model;
using UnityEngine;

namespace Level.Level4.Controll
{
    public partial class Level4Controller:BaseLevelController
    {
        private Level4Model _model = Level4Model.Instance;
        public GameObject PingPotCover,Cat;
        public GameObject CatWant,CatDream;
        public GameObject FireDown, FireUp;
        public GameObject GZup, GZdown;
        public GameObject GZLeft,leftOpen, GZRight,rightopen;
        public GameObject Water;
        public GameObject Pot_1,pot_2,pot_3;
        public GameObject Pot_2_Water, Pot_3_Water;
        public GameObject Bobble;
        public GameObject Can_1, Can_2;
        public GameObject Chlip;
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
            Bobble.SetActive(_model.HasHotWater);
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
            if (_model.PotPos == 2)
            {
                PotFullWater();
            }
        }

        public void PotFullWater()
        {
            _model.PotHasWater = true;
            Pot_2_Water.SetActive(true);
            Pot_3_Water.SetActive(true);
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
                Bobble.SetActive(_model.HasHotWater);
            }
            else
            {
                pot_2.SetActive(true);
                pot_3.SetActive(false);
                _model.PotPos--;
            }
           
        }

        public void PutCan()
        {
            if (Level4Model.Instance.HasHotWater)
            {
                _model.HasPutCan = true;
            }
            Can_1.SetActive(!_model.HasPutCan);
            Can_2.SetActive(_model.HasPutCan);
        }

        public void UseClip()
        {
            if (_model.HasPutCan)
            {
                Chlip.SetActive(false);
                //播放结束动画
            }
        }
    }
}