namespace Ape.Inventory
{
    public class InventorySlot
    {
        public IInventoryItem Item { get; private set; }

        public int Amount { get; private set; }

        public bool IsFull => Amount >= Item.MaxStacks;

        public InventorySlot(IInventoryItem item)
        {
            Item = item;
            Amount = 0;
        }

        public int IncreaseAmount() => IncreaseAmount(1);

        public int IncreaseAmount(int amount)
        {
            var amountLeft = amount;
            while (amountLeft > 0)
            {
                if (Amount == Item.MaxStacks)
                    break;

                ++Amount;
                --amountLeft;
            }

            return amountLeft;
        }
    }
}
