using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    private void Awake()
    {
        //Capasity
        inventory = new Inventory(21);
    }

}
