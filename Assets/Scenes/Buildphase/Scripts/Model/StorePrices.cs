using UnityEngine;

namespace Assets.Scenes.Buildphase.Scripts.Model
{
    [CreateAssetMenu(fileName = "Prices", menuName = "Store/Prices Manager", order = 1)]
    public class StorePrices : ScriptableObject, IStorePrices
    {
        [field: Header("Base upgrades")]
        [field: SerializeField]
        public int FireRateUpgradePrice { get; }
        [field: SerializeField]
        public float FireRateUpgradeValue { get; }
        [field: SerializeField]
        public int SlowRateUpgradePrice { get; }
        [field: SerializeField]
        public float SlowRateUpgradeValue { get; }
        [field: SerializeField]
        public int DamageUpgradePrice { get; }
        [field: SerializeField]
        public int DamageUpgradeValue { get; }
        [field: SerializeField]
        public int HeathUpgradePrice { get; }
        [field: SerializeField]
        public int HeathUpgradeValue { get; }
    }
}