using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Rigidbody2D itemRB;
    
    
    public CollectableType type;
    public Sprite icon;

    private void Awake()
    {
        itemRB = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (collision.gameObject.CompareTag("Player"))
        {
            player.inventory.Add(this);
            Debug.Log("Add");
            Destroy(this.gameObject);
        }
    }
}

public enum CollectableType
{
    NONE, CARROT_SEED
}
