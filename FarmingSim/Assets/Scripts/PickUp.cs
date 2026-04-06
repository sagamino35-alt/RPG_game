using UnityEngine;

public class PickUp : MonoBehaviour
{
    public CollectableType type;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (collision.gameObject.CompareTag("Player"))
        {
            player.inventory.Add(type);
            Debug.Log("Add");
            Destroy(this.gameObject);
        }
    }
}

public enum CollectableType
{
    NONE, CARROT_SEED
}
