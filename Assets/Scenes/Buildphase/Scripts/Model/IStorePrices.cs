namespace Assets.Scenes.Buildphase.Scripts.Model
{
    public interface IStorePrices
    {
        int DamageUpgradePrice { get; }
        int HeathUpgradePrice { get; }
        int FireRateUpgradePrice { get; }
        int SlowRateUpgradePrice { get; }

        int DamageUpgradeValue { get; }
        int HeathUpgradeValue { get; }
        float FireRateUpgradeValue { get; }
        float SlowRateUpgradeValue { get; }
    }
}