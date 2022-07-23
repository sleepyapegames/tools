namespace Ape.Inventory
{
    public class InventorySlot
    {
        /// <summary>
        /// item type on this slot
        /// </summary>
        public IInventoryItem Item { get; private set; }

        /// <summary>
        /// how many item available on this slot
        /// </summary>
        public int Amount { get; private set; }

        /// <summary>
        /// return true if item amount higher or equals to <see cref="IInventoryItem.MaxStacks"/>
        /// </summary>
        public bool IsFull => Amount >= Item.MaxStacks;

        /// <summary>
        /// create new slot
        /// </summary>
        /// <param name="item"></param>
        public InventorySlot(IInventoryItem item)
        {
            Item = item;
            Amount = 0;
        }

        /// <summary>
        /// increase item amount on this slots by 1
        /// </summary>
        /// <returns>return 1 if failed</returns>
        public int IncreaseAmount() => IncreaseAmount(1);

        /// <summary>
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>the amount of item that not added to slots</returns>
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
