using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Inventory : MonoBehaviour
    {
        public Dictionary<int, ItemGroup> items = new Dictionary<int, ItemGroup>();

        public void AddItemGroup(ItemGroup itemGroup)
        {
            int itemID = itemGroup.itemID;
            if (items.ContainsKey(itemID))
            {
                items[itemID].itemAmount += itemGroup.itemAmount;
            }
            else
            {
                var itemGroupCopy = new ItemGroup()
                {
                    itemID = itemID,
                    itemAmount = itemGroup.itemAmount
                };
                items.Add(itemID, itemGroupCopy);
            }
        }

        public void AddItem(int itemID)
        {
            if (items.ContainsKey(itemID))
            {
                items[itemID].itemAmount++;
            }
            else
            {
                var itemGroup = new ItemGroup()
                {
                    itemID = itemID,
                    itemAmount = 1
                };
                items.Add(itemID, itemGroup);
            }
        }

        public void RemoveItem(int itemID)
        {
            var itemGroup = items[itemID];
            if (itemGroup.itemAmount > 1)
            {
                itemGroup.itemAmount--;
            }
            else
            {
                items.Remove(itemID);
            }
        }
        
    }
}