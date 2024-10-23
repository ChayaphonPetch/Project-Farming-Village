using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{

    public int _GoldCoins;
    public int _Days;
    public int _Hours;
    public int _Minutes;
    public bool _iAM;
    //public Vector3 playerPosition;

    public GameData()
    {
        this._GoldCoins = 100;
        this._Days = 1;
        this._Hours = 6;
        this._Minutes = 30;
        this._iAM = true;
       // playerPosition = Vector3.zero;
    }
}
