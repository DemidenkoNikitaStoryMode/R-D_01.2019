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
            if (Damage)            
                Damage.upgradeStat.onClick.AddListener(() => UpgradeAction(UpgradeType.Damage));
            

            if (Health)          
                Health.upgradeStat.onClick.AddListener(() => UpgradeAction(UpgradeType.Health));
            

            if (FireRate)
                Damage.upgradeStat.onClick.AddListener(() => UpgradeAction(UpgradeType.FireRate));
            

            if (SlowDownFactor)
                Damage.upgradeStat.onClick.AddListener(() => UpgradeAction(UpgradeType.SlowDown));
            
        }

        public void SetDamage(int min, int max)
        {
            if (!Damage)
            {
                Debug.Log("Damage==null");
                return;
            }

            Damage.value.text = min + " ~ " + max;
        }

        public void SetHealth(int health)
        {
            if (!Health)
            {
                Debug.Log("Health==null");
                return;
            }

            Health.value.text = health.ToString();
        }

        public void SetFireRate(float fireRate)
        {
            if (!FireRate)
            {
                Debug.Log("FireRate==null");
                return;
            }

            FireRate.value.text = fireRate.ToString();
        }

        public void SetSlowDownFactor(float slowDownPercent)
        {
            if (!SlowDownFactor)
            {
                Debug.Log("SlowDownFactor==null");
                return;
            }

            SlowDownFactor.value.text = slowDownPercent.ToString() + "%";
        }

        public void SetMoney(int money)
        {
            if (!Money)
            {
                Debug.Log("Money==null");
                return;
            }

            Money.value.text = money.ToString();
        }
    }
}