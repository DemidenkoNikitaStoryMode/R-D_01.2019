using System;
using Assets.Scenes.Buildphase.Scripts.Model;
using Assets.Scenes.Buildphase.Scripts.View;
using Assets.Scripts.Model;

namespace Assets.Scenes.Buildphase.Scripts
{
    public class UpgradeManager
    {
        private TowerStats TowerStats => model.TowerStats;
        private PlayerStats PlayerStats => model.PlayerStats;

        private readonly GameModel model;
        private readonly IUpgradeView upgradeView;
        private readonly IStorePrices storePrices;
    
        public UpgradeManager(
            GameModel model,
            IUpgradeView view,
            IStorePrices storePrices)
        {
            this.model = model;
            this.storePrices = storePrices;
            upgradeView = view;
            InitUi();
        }

        private void InitUi()
        {
            upgradeView.UpgradeAction = UpgradeBase;
            UpdateUi();
        }

        private void UpdateUi()
        {
            upgradeView.SetDamage(TowerStats.MinDamage, TowerStats.MaxDamage);
            upgradeView.SetFireRate(TowerStats.FireRate);
            upgradeView.SetHealth(TowerStats.MaxHealth);
            upgradeView.SetMoney(model.Money);
            upgradeView.SetSlowDownFactor(TowerStats.SlowFactor);
        }

        private int GetBaseUpgradePrice(BaseUpgradeType baseUpgradeType)
        {
            switch (baseUpgradeType)
            {
                case BaseUpgradeType.Damage:
                    return storePrices.DamageUpgradePrice;
                case BaseUpgradeType.FireRate:
                    return storePrices.FireRateUpgradePrice;
                case BaseUpgradeType.Health:
                    return storePrices.HeathUpgradePrice;
                case BaseUpgradeType.SlowDown:
                    return storePrices.SlowRateUpgradePrice;
                default:
                    throw new ArgumentOutOfRangeException(nameof(baseUpgradeType),
                        baseUpgradeType, null);
            }
        }

        public void UpgradeBase(BaseUpgradeType baseUpgradeType)
        {
            var upgradePrice = GetBaseUpgradePrice(baseUpgradeType);
            if (upgradePrice > model.Money)
                throw new NotEnoughMoney(
                    "Not enough money to buy it", 
                    model.Money, 
                    upgradePrice
                );
            model.Money -= upgradePrice;

            switch (baseUpgradeType)
            {
                case BaseUpgradeType.Damage:
                    TowerStats.MinDamage += storePrices.DamageUpgradePrice;
                    TowerStats.MaxDamage += storePrices.DamageUpgradePrice;
                    break;
                case BaseUpgradeType.FireRate:
                    TowerStats.FireRate -= storePrices.FireRateUpgradeValue;
                    break;
                case BaseUpgradeType.Health:
                    TowerStats.MaxHealth += storePrices.HeathUpgradeValue;
                    break;
                case BaseUpgradeType.SlowDown:
                    TowerStats.SlowFactor += storePrices.SlowRateUpgradeValue;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(baseUpgradeType),
                        baseUpgradeType, null);
            }

            UpdateUi();
        }
    }
}
