using System;
using Assets.Scenes.Buildphase.Scripts.Model;
using UnityEngine;

namespace Assets.Scenes.Buildphase.Scripts.View
{
    public class UpgradeView : MonoBehaviour, IUpgradeView
    {
        public StorePrices StorePrices;
        public Action<BaseUpgradeType> UpgradeAction { get; set; }

        [Header("Stats views.")]
        public StatView Damage;
        public StatView Health;
        public StatView FireRate;
        public StatView SlowDownFactor;
        public StatView Money;

        private void Start()
        {

            Damage.upgradeStat.onClick.AddListener(() => UpgradeAction(BaseUpgradeType.Damage));
            Health.upgradeStat.onClick.AddListener(() => UpgradeAction(BaseUpgradeType.Health));
            FireRate.upgradeStat.onClick.AddListener(() => UpgradeAction(BaseUpgradeType.FireRate));
            SlowDownFactor.upgradeStat.onClick.AddListener(() => UpgradeAction(BaseUpgradeType.SlowDown));
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