namespace Ape.Inventory.Tests
{
    public class Item : IInventoryItem
    {
        private int _maxStacks;

        public int MaxStacks => _maxStacks;

        public Item(int maxStacks) => _maxStacks = maxStacks;
    }
}
