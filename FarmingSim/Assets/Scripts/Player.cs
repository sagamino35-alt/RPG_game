using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    private void Awake()
    {
        
        inventory = new Inventory(21);
    }

    public void DropItem(PickUp item)
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
        PickUp dropItem = Instantiate(item, spawnLocation, Quaternion.identity);


         //drop effect
         dropItem.itemRB.AddForce(spawnLocation * .2f, ForceMode2D.Impulse);

    }
}




