using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<string, Inventory> inventoryByName = new Dictionary<string, Inventory>();


    [Header("mainInv")]

    public Inventory mainInv;
    public int mainInvSlotsCount;

    [Header("Toolbar")]
    public Inventory toolbar;
    public int toolbarSlotsCount;


    private void Awake()
    {
        mainInv = new Inventory(mainInvSlotsCount);
        toolbar = new Inventory(toolbarSlotsCount);

        inventoryByName.Add("MainInv", mainInv);
        inventoryByName.Add("Toolbar", toolbar);

    }

    public Inventory GetInventoryByName(string inventoryName)
    {
        if (inventoryByName.ContainsKey(inventoryName))
        {
            return inventoryByName[inventoryName];
        }

        return null;

    }

}
