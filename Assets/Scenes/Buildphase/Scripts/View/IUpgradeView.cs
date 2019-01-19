using System;
using Assets.Scenes.Buildphase.Scripts.Model;

namespace Assets.Scenes.Buildphase.Scripts.View
{
    public interface IUpgradeView
    {
        Action<UpgradeType> UpgradeAction { get; set; }

        void SetDamage(int min, int max);
        void SetHealth(int health);
        void SetFireRate(float fireRate);
        void SetSlowDownFactor(float slowDownPercent);
        void SetMoney(int money);
    }
}