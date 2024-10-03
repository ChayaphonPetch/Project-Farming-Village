using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterItemSpawn : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] StarterItem;

    private void Start()
    {
        PickupAllItems();
    }
    public void PickupAllItems()
    {
        bool allItemsAdded = true;

        foreach (var StarterItem in StarterItem)
        {
            bool result = inventoryManager.AddItem(StarterItem);

            if (result == true)
            {
                Debug.Log("Item Added: " + StarterItem.name);
            }
            else
            {
                Debug.Log("Inventory is full! Couldn't add: " + StarterItem.name);
                allItemsAdded = false;
            }
        }

        if (allItemsAdded)
        {
            Debug.Log("All items added successfully.");
        }
        else
        {
            Debug.Log("Some items couldn't be added due to full inventory.");
        }
    }
}
