
using UnityEngine;
using UnityEngine.Tilemaps;

public class InteractableTileManager : MonoBehaviour
{
    [SerializeField] Tilemap interactableMap;
    [SerializeField] Tile InvisibleTile;

    [SerializeField] Tile TilledTile;
   

    void Start()
    {
       

        foreach (var position in interactableMap.cellBounds.allPositionsWithin)
        {
            if (interactableMap.HasTile(position))
            {
                
                interactableMap.SetTile(position, InvisibleTile);
            }
        }
    }

    public bool IsTileInteractable(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);
        if (tile != null)
        {
            if (tile.name == "Interactable_Tile_Invisible")
            {
                return true;
            }
        }

        return false;

    }

    public void SetTilledTile(Vector3Int position)
    {
       
        interactableMap.SetTile(position, TilledTile);

    }



}
