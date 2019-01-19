using UnityEngine;

namespace Assets.Scenes.Buildphase.Scripts.Model
{
    [CreateAssetMenu(fileName = "Prices", menuName = "Store/Prices Manager", order = 1)]
    public class StorePrices : ScriptableObject, IStorePrices
    {
        [Header("Base upgrades")]
        [SerializeField]
        private int fireRateUpgradePrice;
        [SerializeField]
        private float fireRateUpgradeValue;
        [SerializeField]
        private int slowRateUpgradePrice;
        [SerializeField]
        private float slowRateUpgradeValue;
        [SerializeField]
        private int damageUpgradePrice;
        [SerializeField]
        private int damageUpgradeValue;
        [SerializeField]
        private int heathUpgradePrice;
        [SerializeField]
        private int heathUpgradeValue;

        public int FireRateUpgradePrice => fireRateUpgradePrice;
        public float FireRateUpgradeValue => fireRateUpgradeValue;
        public int SlowRateUpgradePrice => slowRateUpgradePrice;
        public float SlowRateUpgradeValue => slowRateUpgradeValue;
        public int DamageUpgradePrice => damageUpgradePrice;
        public int DamageUpgradeValue => damageUpgradeValue;
        public int HeathUpgradePrice => heathUpgradePrice;
        public int HeathUpgradeValue => heathUpgradeValue;
    }
}