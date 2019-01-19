using System;
using Assets.Scenes.Buildphase.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.Buildphase.Scripts.View
{
    public class UpgradeView : MonoBehaviour, IUpgradeView
    {
        public Action<UpgradeType> UpgradeAction { get; set; }

        [Header("Stats views.")]
        public StatView Damage;
        public StatView Health;
        public StatView FireRate;
        public StatView SlowDownFactor;
        public StatView Money;

        private void Start()
        {

            Damage.upgradeStat.onClick.AddListener(() => UpgradeAction(UpgradeType.Damage));
            Health.upgradeStat.onClick.AddListener(() => UpgradeAction(UpgradeType.Health));
            FireRate.upgradeStat.onClick.AddListener(() => UpgradeAction(UpgradeType.FireRate));
            SlowDownFactor.upgradeStat.onClick.AddListener(() => UpgradeAction(UpgradeType.SlowDown));
            //Money
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