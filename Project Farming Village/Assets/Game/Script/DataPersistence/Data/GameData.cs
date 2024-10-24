using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public string _Name = "";
    public int _GoldCoins;
    public int _Days;
    public int _Hours;
    public int _Minutes;
    public bool _iAM;
    public string Season;
    public string Weather;
    //public Vector3 playerPosition;

    public List<InventoryItemData> inventoryItems;

    public GameData()
    {
        this._Name = "Player";
        this._GoldCoins = 100;
        this._Days = 1;
        this._Hours = 6;
        this._Minutes = 30;
        this._iAM = true;
        this.Season = "Summer";
        this.Weather = "Clear";

        // playerPosition = Vector3.zero;

        this.inventoryItems = new List<InventoryItemData>();
    }

}

[System.Serializable]
public class InventoryItemData
{
    public string itemName;
    public int count;
    public int slotIndex; // Add this field to track the slot index

    public InventoryItemData(string itemName, int count, int slotIndex)
    {
        this.itemName = itemName;
        this.count = count;
        this.slotIndex = slotIndex; // Initialize the slot index
    }
}