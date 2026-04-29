using UnityEngine;


[RequireComponent(typeof(Item))]
public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (collision.gameObject.CompareTag("Player"))
        {
            Item item = GetComponent<Item>();

            if (item != null)
            {
                player.inventory.Add(item);
                Destroy(this.gameObject);
            }

            
        }
    }
}

