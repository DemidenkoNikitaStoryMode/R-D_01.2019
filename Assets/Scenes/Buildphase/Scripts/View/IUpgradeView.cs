using System;
using Assets.Scenes.Buildphase.Scripts.Model;
using Assets.Scripts.Model;

namespace Assets.Scenes.Buildphase.Scripts.View
{
    public interface IUpgradeView
    {
        Action<BaseUpgradeType> UpgradeBaseAction { get; set; }
        Action<PlayerUpgradeType> UpgradePlayerAction { get; set; }

        void UpdatePlayerStats(PlayerStats playerStats);
        void UpdateTowerStats(TowerStats towerStats);
    }
}