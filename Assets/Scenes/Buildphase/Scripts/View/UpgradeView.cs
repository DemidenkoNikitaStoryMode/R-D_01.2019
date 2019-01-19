using System;
using Assets.Scenes.Buildphase.Scripts.Model;
using UnityEngine;

namespace Assets.Scenes.Buildphase.Scripts.View
{
    public class UpgradeView : MonoBehaviour, IUpgradeView
    {
        private bool IsOnTowerScreen = true;

        public StorePrices StorePrices;
        public Action<BaseUpgradeType> UpgradeAction { get; set; }

        [SerializeField]
        private WidgetsManager widgetManager;

        [SerializeField]
        private BaseWidget defaultWidget;
        [SerializeField]
        private TowerStatsWidget towerStatsWidget;
        [SerializeField]
        private PlayerStatsWidget playerStatsWidget;
        [SerializeField]
        private PlayerAbilitiesWidget playerAbilitiesWidget;
        [SerializeField]
        private TowerAbilitiesWidget towerAbilitiesWidget;
        [SerializeField]
        private TopBarWidget topBarWidget;

        

        private void Start()
        {
            widgetManager.ShowWidget(defaultWidget);

            towerStatsWidget.Damage.upgradeStat.onClick.AddListener(() => UpgradeAction(BaseUpgradeType.Damage));
            towerStatsWidget.Health.upgradeStat.onClick.AddListener(() => UpgradeAction(BaseUpgradeType.Health));
            towerStatsWidget.FireRate.upgradeStat.onClick.AddListener(() => UpgradeAction(BaseUpgradeType.FireRate));
            towerStatsWidget.SlowDownFactor.upgradeStat.onClick.AddListener(() => UpgradeAction(BaseUpgradeType.SlowDown));
            //topBarWidget.Money.upgradeStat.onClick.AddListener(() => UpgradeAction(BaseUpgradeType.Money));
        }

        public void SetDamage(int min, int max)
        {
            //towerStatsWidget.SetDamage();
            towerStatsWidget.Damage.value.text = min + " ~ " + max;
        }

        public void SetHealth(int health)
        {
            towerStatsWidget.Health.value.text = health.ToString();
        }

        public void SetFireRate(float fireRate)
        {
            towerStatsWidget.FireRate.value.text = fireRate.ToString();
        }

        public void SetSlowDownFactor(float slowDownPercent)
        {
            towerStatsWidget.SlowDownFactor.value.text = slowDownPercent.ToString() + "%";
        }

        public void SetMoney(int money)
        {
            topBarWidget.Money.value.text = money.ToString();
        }

        public void OnStats()
        {
            BaseWidget widget = playerStatsWidget;

            //if (!IsOnTowerScreen)
                widget = towerStatsWidget;

            widgetManager.ShowWidget(widget);

            //IsOnTowerScreen = !IsOnTowerScreen;
        }
    }
}