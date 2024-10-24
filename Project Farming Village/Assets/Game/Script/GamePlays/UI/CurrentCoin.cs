using UnityEngine;
using TMPro;

public class CurrentCoin : MonoBehaviour, IDataPersistence
{
    public TextMeshProUGUI Coin_Display;
    public int _CurrentCoin;

    void Update()
    {
        Coin_Display.text = "Gold: " + _CurrentCoin.ToString();
    }

    public void LoadData(GameData data)
    {
        this._CurrentCoin = data._GoldCoins;
    }

    // Save the current amount of gold coins
    public void SaveData(ref GameData data)
    {
        data._GoldCoins = this._CurrentCoin;
    }
}
