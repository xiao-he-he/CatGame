using Level.Model;
using Unity.VisualScripting;

namespace Level.Level4.Model
{
    public class Level4Model:BaseLevelModel<Level4Model>
    {
        public bool OpenPingPot = false;
        public bool OpenFireDown = false;
        public bool OpenFireUp = false;

        public bool OpenUpCabinet;
        public bool OpenDownCabinet;

        public bool OpenLeftCabinet;
        public bool OpenRightCabinet;

        public bool OpenWater;
        public int PotPos = 1;

        public bool PotHasWater;
        public bool HasHotWater =>OpenFireDown && PotPos == 3 && PotHasWater;
        public bool HasPutCan;
    }
}