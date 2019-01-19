using System;

namespace Assets.Scenes.Buildphase.Scripts
{
    public class NotEnoughMoney : Exception
    {
        public int RequiredMoney { get; }
        public int AvailableMoney { get; }

        public NotEnoughMoney(string message, int requiredMoney, int availableMoney)
            : base(message)
        {
            RequiredMoney = requiredMoney;
            AvailableMoney = availableMoney;
        }
    }
}