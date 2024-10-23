using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Create Item/Item")]
public class Item : ScriptableObject {

    [Header("Only Gameplay")]
    public TileBase tile;
    public ItemType type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]
    public bool stackable = true;
    public bool sellable = false;

    [HideInInspector]
    public int price;

    [Header("both")]
    public Sprite image;

    public int Item_Id;
}

public enum ItemType
{
    TEST, Tool, Seed
}

public enum ActionType
{
    TEST, Digging, Cutting, Watering, Plowing, Plant
}


