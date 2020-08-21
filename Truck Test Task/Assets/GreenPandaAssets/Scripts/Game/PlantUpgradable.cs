namespace GreenPandaAssets.Scripts
{
    public class PlantUpgradable : AUpgradable
    {
        public PlantView FactoryView;

        private void Update()
        {
        
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
            
            FactoryView.SetSkinLevel(skinLevel);
        }
    }
}