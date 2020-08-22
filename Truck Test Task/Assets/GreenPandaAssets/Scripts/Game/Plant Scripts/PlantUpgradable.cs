namespace GreenPandaAssets.Scripts
{
    public class PlantUpgradable : AUpgradable
    {
        public PlantView PlantView;

        public void SetupSettings(PlantConfig config)
        {
            _level = config.StartLevel;
            _maxLevel = config.MaxLevelPlant;
            _startPrice = config.StartPrice;
            _priceStepFactor = config.PriceStepFactor;
            PlantView.PlantSkins = config.Skins;
            PlantView.SetupView();
        }
        
        public override void Upgrade()
        {
            base.Upgrade();

            //TODO: norm upgrade every 5 levels
            var skinLevel = -1;
            
            if (_level <= 5)
            {
                skinLevel = 1;
            }
            else if (_level <= 10)
            {
                skinLevel = 2;
            }
            else
            {
                skinLevel = 3;
            }
            
            PlantView.SetSkinLevel(skinLevel);
        }
    }
}