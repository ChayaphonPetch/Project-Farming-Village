using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Create Plants/Plants")]
public class Plants : ScriptableObject
{

    [Header("Plants Data")]
    public string PlantName;

    public int DayGlowing;

    public Sprite Level1;
    public Sprite Level2;
    public Sprite Level3;


}




