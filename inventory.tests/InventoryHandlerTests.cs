using System.Linq;
using NUnit.Framework;

namespace Ape.Inventory.Tests
{
    public class InventoryHandlerTests
    {
        [Test]
        [
            TestCase(10, 1, 10, 0, 10),
            TestCase(10, 10, 10, 0, 1),
            TestCase(1, 10, 10, 0, 1),
            TestCase(1, 10, 100, 90, 1),
            TestCase(10, 10, 100, 0, 10),
            TestCase(int.MaxValue, 10, 100, 0, 10),
        ]
        public void AddItemTest(
            int maxSlots,
            int maxStacks,
            int addAmount,
            int expectedAmountLeft,
            int expectedSlotsCount
        )
        {
            var item = new Item(maxStacks);
            var inventory = new InventoryHandler(maxSlots);
            var amountLeft = inventory.AddItem(item, addAmount);

            Assert.AreEqual(expectedAmountLeft, amountLeft);
            Assert.AreEqual(expectedSlotsCount, inventory.Slots.Count());
        }
    }
}
