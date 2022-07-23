namespace Ape.Inventory
{
    public interface IInventoryItem
    {
        /// <summary>
        /// maximum amount of item on slots
        /// </summary>
        int MaxStacks { get; }
    }
}
