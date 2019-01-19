using Assets.Scenes.Buildphase.Scripts.Model;
using Assets.Scenes.Buildphase.Scripts.View;

namespace Assets.Scenes.Buildphase.Scripts
{
    public class UpgradeManager
    {
        private GameModel model;
        private IUpgradeView upgradeView;
    
        public UpgradeManager(GameModel model, IUpgradeView view)
        {
            this.model = model;
            upgradeView = view;
            InitUi();
        }

        private void InitUi()
        {
            upgradeView.SetDamage(model.MinDamage, model.MaxDamage);
            upgradeView.SetFireRate(model.FireRate);
            upgradeView.SetHealth(model.MaxHealth);
            upgradeView.SetMoney(model.Money);
            upgradeView.SetSlowDownFactor(model.SlowFactor);
            upgradeView.UpgradeAction = Upgrade;
        }

        public void Upgrade(UpgradeType upgradeType)
        {
            switch (upgradeType)
            {
                case UpgradeType.Damage:

                    upgradeView.SetDamage(model.MinDamage, model.MaxDamage);

                    break;

                case UpgradeType.Health:

                    upgradeView.SetHealth(model.MaxHealth);

                    break;

                case UpgradeType.FireRate:

                    upgradeView.SetFireRate(model.FireRate);

                    break;

                case UpgradeType.SlowDown:

                    upgradeView.SetSlowDownFactor(model.SlowFactor);

                    break;
            }
        }
    }
}
