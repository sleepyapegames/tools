using System.Collections.Generic;
using System.Linq;

namespace Ape.Inventory
{
    public class InventoryHandler
    {
        private List<InventorySlot> _slots = new List<InventorySlot>();

        public IEnumerable<InventorySlot> Slots => _slots;

        public int MaxSlots { get; private set; }

        public InventoryHandler(int maxSlots) => MaxSlots = maxSlots;

        public int AddItem(IInventoryItem item) => AddItem(item, 1);

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
