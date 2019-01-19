using System;
using Assets.Scenes.Buildphase.Scripts.Model;
using Assets.Scripts.Model;
using UnityEngine;

namespace Assets.Scenes.Buildphase.Scripts.View
{
    public class UpgradeView : MonoBehaviour, IUpgradeView
    {
        public StorePrices StorePrices;
        public Action<BaseUpgradeType> UpgradeBaseAction { get; set; }
        public Action<PlayerUpgradeType> UpgradePlayerAction { get; set; }

        public void UpdatePlayerStats(PlayerStats playerStats)
        {
            throw new NotImplementedException();
        }

        public void UpdateTowerStats(TowerStats towerStats)
        {
            throw new NotImplementedException();
        }

        [Header("Stats views.")]
        public StatView Damage;
        public StatView Health;
        public StatView FireRate;
        public StatView SlowDownFactor;
        public StatView Money;

        private void Start()
        {
            Damage.upgradeStat.onClick.AddListener(() => UpgradeBaseAction(BaseUpgradeType.Damage));
            Health.upgradeStat.onClick.AddListener(() => UpgradeBaseAction(BaseUpgradeType.Health));
            FireRate.upgradeStat.onClick.AddListener(() => UpgradeBaseAction(BaseUpgradeType.FireRate));
            SlowDownFactor.upgradeStat.onClick.AddListener(() => UpgradeBaseAction(BaseUpgradeType.SlowDown));
        }

        public void SetDamage(int min, int max)
        {
            Damage.value.text = min + " ~ " + max;
        }

        public void SetHealth(int health)
        {
            Health.value.text = health.ToString();
        }

        public void SetFireRate(float fireRate)
        {
            FireRate.value.text = fireRate.ToString();
        }

        public void SetSlowDownFactor(float slowDownPercent)
        {
            SlowDownFactor.value.text = slowDownPercent.ToString() + "%";
        }

        public void SetMoney(int money)
        {
            Money.value.text = money.ToString();
        }
    }
}