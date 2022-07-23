using System.Collections.Generic;
using System.Linq;

namespace Ape.Inventory
{
    public class InventoryHandler
    {
        /// <summary>
        /// storing all slots on this inventory
        /// </summary>
        private List<InventorySlot> _slots = new List<InventorySlot>();

        /// <summary>
        /// all slots on this inventory
        /// </summary>
        public IEnumerable<InventorySlot> Slots => _slots;

        /// <summary>
        /// maximum amount of slots this inventory can store
        /// </summary>
        public int MaxSlots { get; private set; }

        /// <summary>
        /// create new inventory
        /// </summary>
        /// <param name="maxSlots"></param>
        public InventoryHandler(int maxSlots) => MaxSlots = maxSlots;

        /// <summary>
        /// add 1 specific item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>return 1 if slots full</returns>
        public int AddItem(IInventoryItem item) => AddItem(item, 1);

        /// <summary>
        /// add specific item with custom amount
        /// </summary>
        /// <param name="item"></param>
        /// <param name="amount"></param>
        /// <returns>the amount of item that not added to slots</returns>
        public int AddItem(IInventoryItem item, int amount)
        {
            var slots = _slots.Where(x => x.Item == item).Where(x => !x.IsFull);
            var amountLeft = amount;

            foreach (var slot in slots)
                amountLeft = slot.IncreaseAmount(amount);

            while (amountLeft > 0 && _slots.Count < MaxSlots)
            {
                var slot = new InventorySlot(item);
                amountLeft = slot.IncreaseAmount(amountLeft);

                _slots.Add(slot);
            }

            return amountLeft;
        }
    }
}
