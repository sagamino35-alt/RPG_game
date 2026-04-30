using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    InputAction tillAction;

    private void Awake()
    {
        
        inventory = new Inventory(27);
    }


    private void Start()
    {
        tillAction = InputSystem.actions.FindAction("Attack");
    }

    private void Update()
    {
        if (tillAction.WasPerformedThisFrame())
        {
            Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);

            if (GameManager.instance.interactableTileManager.IsTileInteractable(position))
            {
                Debug.Log("Tile is interactable");
                GameManager.instance.interactableTileManager.SetTilledTile(position);
            }
        }
        //Checks if player is trying to till a tile and if the tile is interactable, then tills it


    }

    public void DropItem(Item item)
    {
        Vector2 spawnLocation = new Vector2(0,0);
        //Picks location to instantiate dropped Item
        if (transform.localScale.x > 0)
        {
             spawnLocation = transform.position + new Vector3(1.5f, 0f, 0f);
        }
        else
        {
             spawnLocation = transform.position + new Vector3(-1.5f, 0f, 0f);
        }
        
        
        //Instantiates item at location
        Item dropItem = Instantiate(item, spawnLocation, Quaternion.identity);


         //drop effect
         dropItem.itemRB.AddForce(spawnLocation * .2f, ForceMode2D.Impulse);

    }
}




