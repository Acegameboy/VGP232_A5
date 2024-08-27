using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignment5
{
    [TestFixture]
    public class InventoryTest
    {
        [Test]
        public void RemoveItem_FoundItemSet_ReturnsTrue_VerifyAvailableSlotsIncrease()
        {
            // Arrange
            var inventory = new Inventory(5);
            var item = new Item("Key", 1, ItemGroup.Key);
            inventory.AddItem(item);

            // Act
            bool result = inventory.TakeItem("Key", out Item foundItem);

            // ClassicAssert
            ClassicAssert.IsTrue(result);
            ClassicAssert.IsNotNull(foundItem);
            ClassicAssert.AreEqual(5, inventory.AvailableSlots); // Available slots should increase back to max
        }

        [Test]
        public void RemoveItem_ItemNotFound_ReturnsFalse_VerifyAvailableSlotsRemainSame()
        {
            // Arrange
            var inventory = new Inventory(5);
            var item = new Item("Key", 1, ItemGroup.Key);
            inventory.AddItem(item);

            // Act
            bool result = inventory.TakeItem("Sword", out Item foundItem);

            // ClassicAssert
            ClassicAssert.IsFalse(result);
            ClassicAssert.IsNull(foundItem);
            ClassicAssert.AreEqual(4, inventory.AvailableSlots); // Available slots should remain the same
        }

        [Test]
        public void AddItem_VerifyAvailableSlotsDecrease_AndItemExists()
        {
            // Arrange
            var inventory = new Inventory(5);
            var item = new Item("Sword", 1, ItemGroup.Equipment);

            // Act
            bool added = inventory.AddItem(item);
            var allItems = inventory.ListAllItems();

            // ClassicAssert
            ClassicAssert.IsTrue(added);
            ClassicAssert.AreEqual(4, inventory.AvailableSlots); // Available slots should decrease
            ClassicAssert.Contains(item, allItems);
        }

        [Test]
        public void Reset_RemovesAllItems_AndRestoresMaxSlots()
        {
            // Arrange
            var inventory = new Inventory(5);
            inventory.AddItem(new Item("Sword", 1, ItemGroup.Equipment));
            inventory.AddItem(new Item("Key", 1, ItemGroup.Key));

            // Act
            inventory.Reset();

            // ClassicAssert
            ClassicAssert.AreEqual(5, inventory.AvailableSlots); // Max slots restored
            ClassicAssert.IsEmpty(inventory.ListAllItems()); // All items should be removed
        }
    }
}
