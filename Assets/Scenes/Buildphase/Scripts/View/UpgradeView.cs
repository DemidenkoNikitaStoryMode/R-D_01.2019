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

        [Header("Widgets.")]
        [SerializeField]
        private WidgetsManager widgetManager;

        [Space]
        [SerializeField]
        private BaseWidget defaultWidget;

        [Space]
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
        [SerializeField]
        private BottomBarWidget bottomBarWidget;

        

        private void Start()
        {
            widgetManager.ShowWidget(defaultWidget);

            topBarWidget.EnableTowerWidget.onClick.AddListener(EnableTowerWidgets);
            topBarWidget.EnableTowerWidget.onClick.AddListener(EnablePlayerWidgets);
            bottomBarWidget.Stats.onClick.AddListener(ShowStatsWidget);
            bottomBarWidget.Abilities.onClick.AddListener(ShowAbilitiesWidget);

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
            topBarWidget.Money.value.text = "Money: " + money.ToString();
        }

        public void ShowStatsWidget()
        {
            if (IsOnTowerScreen)
            {
                widgetManager.ShowWidget(towerAbilitiesWidget);
            }
            else
            {
                widgetManager.ShowWidget(playerAbilitiesWidget);
            }
        }

        public void ShowAbilitiesWidget()
        {
            if (IsOnTowerScreen)
            {
                widgetManager.ShowWidget(towerAbilitiesWidget);
            }
            else
            {
                widgetManager.ShowWidget(playerAbilitiesWidget);
            }
        }

        public void EnableTowerWidgets()
        {
            widgetManager.ShowWidget(towerStatsWidget);
            IsOnTowerScreen = true;
        }

        public void EnablePlayerWidgets()
        {
            widgetManager.ShowWidget(playerStatsWidget);
            IsOnTowerScreen = false;
        }

        /*public void ShowStatsWidget()
        {
            if(towerStatsWidget.gameObject)
        }*/
    }
}