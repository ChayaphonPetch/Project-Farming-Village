using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tile hiddenInteractableTile;

    void Start()
    {
        // Iterate through all the positions in the tilemap's bounds.
        foreach (var position in interactableMap.cellBounds.allPositionsWithin)
        {
            // Check if there is a tile at the current position.
            if (interactableMap.HasTile(position))
            {
                interactableMap.SetTile(position, hiddenInteractableTile);
            }
        }
    }

    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);

        // Instead of comparing the tile name, compare the actual tile reference
        if (tile != null && tile == hiddenInteractableTile)
        {
            return true;
        }

        return false;
    }
}
