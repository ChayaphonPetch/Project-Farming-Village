using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int playerGold = 0;

    public void AddGold(int amount)
    {
        playerGold += amount;
    }

    public int GetGold()
    {
        return playerGold;
    }

}