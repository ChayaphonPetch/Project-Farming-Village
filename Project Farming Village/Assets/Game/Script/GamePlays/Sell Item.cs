using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellItem : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public PlayerData playerData; // Reference to player data script
    private bool playerInSellZone = false;

    private void Update()
    {
        // Check if player is in the sell zone and presses the E key
        if (playerInSellZone && Input.GetKeyDown(KeyCode.E))
        {
            SellSelectedItem();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the selling zone
        if (other.CompareTag("Player"))
        {
            playerInSellZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the selling zone
        if (other.CompareTag("Player"))
        {
            playerInSellZone = false;
        }
    }

    void SellSelectedItem()
    {
        // Get the currently selected item from the inventory
        Item selectedItem = inventoryManager.GetSelectedItem(false);

        if (selectedItem != null)
        {
            // Check if the item is sellable
            if (selectedItem.sellable)
            {
                // Increase player's gold by the item's price
                playerData.AddGold(selectedItem.price);

                // Remove the selected item from the inventory

                Debug.Log($"Sold {selectedItem.name} for {selectedItem.price} gold. Total gold: {playerData.GetGold()}");
            }
            else
            {
                Debug.Log("This item cannot be sold.");
            }
        }
        else
        {
            Debug.Log("No item selected to sell.");
        }
    }
}
