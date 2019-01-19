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

        public void SetDamage(int min, int max)
        {
            throw new System.NotImplementedException();
        }

        public void SetHealth(int health)
        {
            throw new System.NotImplementedException();
        }

        public void SetFireRate(float fireRate)
        {
            throw new System.NotImplementedException();
        }

        public void SetSlowDownFactor(float slowDownPercent)
        {
            throw new System.NotImplementedException();
        }

        public void SetMoney(int money)
        {
            throw new System.NotImplementedException();
        }
    }
}