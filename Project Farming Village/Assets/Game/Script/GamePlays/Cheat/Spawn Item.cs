using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour, IDataPersistence
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;
    public ClockTime clockTime;
    public CurrentCoin currentCoinScript;

    public int _days = 1;
    public int _hours = 6;
    public int _minutes = 30;
    public int _Goldcoin;
    public bool _am = true;

    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickup[id]);

        if (result == true)
        {
            Debug.Log("Item Added");
        }
        else
        {
            Debug.Log("Inventory has full!!");
        }
    }

    public void RandomItem()
    {
        int id = Random.Range(0, itemsToPickup.Length);

        bool result = inventoryManager.AddItem(itemsToPickup[id]);
        if (result)
        {
            Debug.Log("Item Added");
        }
        else
        {
            Debug.Log("Inventory is full!!");
        }
    }

    public void GetSelectItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(false);
        if (receivedItem != null)
        {
            Debug.Log("Use Item: " + receivedItem.name);
        }
        else
        {
            Debug.Log("No Item");
        }
    }

    public void UseGetSelectItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(true);
        if (receivedItem != null)
        {
            Debug.Log("Used Item: " + receivedItem.name);
        }
        else
        {
            Debug.Log("No Item");
        }
    }

    public void DaySkip()
    {
        _days++;
        _hours = 6;
        _minutes = 30;
        _am = true;
        if (_days >= 31)
        {
            _days = 1;
        }
        DataPersistenceManager.Instance.SaveGame();
        Debug.Log("Day skipped. \n" + "Current Day: " + this._days);

    }

    public void GainGoldCoin()
    {
        _Goldcoin += 100;
        Debug.Log($"Gain Coin 100+\n" + "Gold coins total: " + _Goldcoin);
    }

    public void LoadData(GameData data)
    {
        this._days = data._Days;
        this._hours = data._Hours;
        this._minutes = data._Minutes;
        this._am = data._iAM;
        this._Goldcoin = data._GoldCoins;   
    }

    // Save the current day, time, and AM/PM status
    public void SaveData(ref GameData data)
    {
        data._Days = this._days;
        data._Hours = this._hours;
        data._Minutes = this._minutes;
        data._iAM = this._am;
        data._GoldCoins = this._Goldcoin;
    }
}