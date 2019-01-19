using System;
using Assets.Scenes.Buildphase.Scripts.Model;
using Assets.Scenes.Buildphase.Scripts.View;

namespace Assets.Scenes.Buildphase.Scripts
{
    public class UpgradeManager
    {
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
            upgradeView.SetDamage(model.MinDamage, model.MaxDamage);
            upgradeView.SetFireRate(model.FireRate);
            upgradeView.SetHealth(model.MaxHealth);
            upgradeView.SetMoney(model.Money);
            upgradeView.SetSlowDownFactor(model.SlowFactor);
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
                    model.MinDamage += storePrices.DamageUpgradePrice;
                    model.MaxDamage += storePrices.DamageUpgradePrice;
                    break;
                case BaseUpgradeType.FireRate:
                    model.FireRate -= storePrices.FireRateUpgradeValue;
                    break;
                case BaseUpgradeType.Health:
                    model.MaxHealth += storePrices.HeathUpgradeValue;
                    break;
                case BaseUpgradeType.SlowDown:
                    model.SlowFactor += storePrices.SlowRateUpgradeValue;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(baseUpgradeType),
                        baseUpgradeType, null);
            }

            UpdateUi();
        }
    }
}
