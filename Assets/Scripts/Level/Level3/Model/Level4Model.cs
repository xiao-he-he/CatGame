using Level.Model;

namespace Level.Level3.Model
{
    public class Level3Model:BaseLevelModel<Level3Model>
    {
        public bool CatInUp = true;
        public bool UpIsOpen = true;
        public bool DownIsOpen = true;
        public bool HasElectricity;
        public bool UpIsUse;
        public bool DownIsUes;
    }
}