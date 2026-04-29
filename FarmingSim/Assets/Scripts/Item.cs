using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class Item : MonoBehaviour
{
    public ItemData data;

    [HideInInspector] public Rigidbody2D itemRB;
    private void Awake()
    {
        itemRB = GetComponent<Rigidbody2D>();
    }




}
