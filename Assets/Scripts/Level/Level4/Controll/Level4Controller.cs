using System;
using System.Threading;
using Cysharp.Threading.Tasks;
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
        public GameObject PotCover;
        public GameObject OverWater;
        public GameObject SuccessChilp;
        public GameObject WaterFall,FireFaill;
        private CancellationTokenSource _cts;
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

        public async void OpenUpFire()
        {
            _model.OpenFireUp = !_model.OpenFireUp;
            FireUp.SetActive(_model.OpenFireUp);
            await UniTask.WaitForSeconds(0.5f);
            PingPotCover.SetActive(false);
            Cat.SetActive(true);
            Cat.GetComponent<SpriteRenderer>().color = Color.red;
            await UniTask.WaitForSeconds(0.5f);
            FireFaill.SetActive(true);
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
            if (!_model.OpenWater)
            {
                Debug.Log("关闭");
                StopOverwater();
            }
            if (_model.PotPos == 2&&_model.OpenWater&&!_model.PotHasWater)
            {
                PotFullWater();
            }
            else if(_model.OpenWater)
            {
                StartOverwater();
            }
            
        }

        public void StartOverwater() {
            // 先终止旧任务（避免重复启动）
            StopOverwater();
            _cts = new CancellationTokenSource();
            Overwater(_cts.Token).Forget();
        }
       

        // 终止方法
        public void StopOverwater()
        {
            if (_cts != null)
            {
                _cts.Cancel(); // 触发取消
                _cts.Dispose(); // 释放资源
                _cts = null; // 重置引用
                OverWater.SetActive(false); // 兜底关闭
            }
        }

        // async void Overwater()
        // {
        //     OverWater.SetActive(true);
        //     await UniTask.WaitForSeconds(3);
        //     Debug.Log("游戏失败");
        // }
        public async void PotFullWater()
        {
            Pot_2_Water.SetActive(true);
            _model.PotHasWater = true;
            Pot_3_Water.SetActive(true);
            await UniTask.WaitForSeconds(2);
            
            Pot_2_Water.GetComponent<Animator>().enabled = false;
            if (_model.PotPos == 2&&_model.OpenWater)
            {
                StartOverwater();
            }
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
                if (_model.OpenWater)
                {
                    StartOverwater();
                }
            }
            else
            {
                if (!_model.HasHotWater)
                {
                    pot_2.SetActive(true);
                    pot_3.SetActive(false);
                    _model.PotPos--;
                }
                
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
            PotCover.SetActive(_model.HasPutCan);
            //PotCover.SetActive(_model.OpenFireDown);
        }

        public void UseClip()
        {
            if (_model.HasPutCan&&_model.OpenPingPot)
            {
                Chlip.SetActive(false);
                PotCover.SetActive(false);
                SuccessChilp.SetActive(true);
                //播放结束动画
            }
        }


        public void OverWaterFail()
        {
            
        }
    }

    public partial class Level4Controller
    {
        private async UniTaskVoid Overwater(CancellationToken ct) {
            OverWater.SetActive(true);
            try {
                await UniTask.WaitForSeconds(3, cancellationToken: ct);
                Debug.Log("游戏失败");
                WaterFall.SetActive(true);
                await UniTask.WaitForSeconds(1);
                //重新开始
            } catch (OperationCanceledException) {
                Debug.Log("任务被取消");
            } finally {
                OverWater.SetActive(false); // 确保无论是否取消都关闭
            }
        }
    }
}