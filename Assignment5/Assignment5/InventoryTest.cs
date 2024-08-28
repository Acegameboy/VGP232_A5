using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Assignment5
{
    [TestFixture]
    public class InventoryTest
    {
        [Test]
        public void RemoveItem_FoundItemSet_ReturnsTrue_VerifyAvailableSlotsIncrease()
        {
            var inventory = new Inventory(5);
            var item = new Item("Key", 1, ItemGroup.Key);
            inventory.AddItem(item);

            bool result = inventory.TakeItem("Key", out Item foundItem);

            ClassicAssert.IsTrue(result);
            ClassicAssert.IsNotNull(foundItem);
            ClassicAssert.AreEqual(5, inventory.AvailableSlots); 
        }

        [Test]
        public void RemoveItem_ItemNotFound_ReturnsFalse_VerifyAvailableSlotsRemainSame()
        {
            var inventory = new Inventory(5);
            var item = new Item("Key", 1, ItemGroup.Key);
            inventory.AddItem(item);

            bool result = inventory.TakeItem("Sword", out Item foundItem);

            ClassicAssert.IsFalse(result);
            ClassicAssert.IsNull(foundItem);
            ClassicAssert.AreEqual(4, inventory.AvailableSlots); 
        }

        [Test]
        public void AddItem_VerifyAvailableSlotsDecrease_AndItemExists()
        {
            var inventory = new Inventory(5);
            var item = new Item("Sword", 1, ItemGroup.Equipment);

            bool added = inventory.AddItem(item);
            var allItems = inventory.ListAllItems();

            ClassicAssert.IsTrue(added);
            ClassicAssert.AreEqual(4, inventory.AvailableSlots); 
            ClassicAssert.Contains(item, allItems);
        }

        [Test]
        public void Reset_RemovesAllItems_AndRestoresMaxSlots()
        {
            var inventory = new Inventory(5);
            inventory.AddItem(new Item("Sword", 1, ItemGroup.Equipment));
            inventory.AddItem(new Item("Key", 1, ItemGroup.Key));

            inventory.Reset();

            ClassicAssert.AreEqual(5, inventory.AvailableSlots); 
            ClassicAssert.IsEmpty(inventory.ListAllItems()); 
        }
    }
}
