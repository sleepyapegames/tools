using NUnit.Framework;

namespace Ape.Inventory.Tests
{
    public class InventorySlotTests
    {
        [Test]
        [
            TestCase(1, 10, 9, true),
            TestCase(10, 10, 0, true),
            TestCase(10, 11, 1, true),
            TestCase(10, 1, 0, false),
            TestCase(100, 1, 0, false),
            TestCase(1, 90, 89, true),
            TestCase(10, 90, 80, true),
            TestCase(int.MaxValue, 90, 0, false),
        ]
        public void IncreaseAmountTest(
            int maxStacks,
            int increaseAmount,
            int expectedReturn,
            bool shouldFull
        )
        {
            var item = new Item(maxStacks);
            var slot = new InventorySlot(item);

            var left = slot.IncreaseAmount(increaseAmount);
            Assert.AreEqual(expectedReturn, left);
            Assert.AreEqual(shouldFull, slot.IsFull);
        }
    }
}
