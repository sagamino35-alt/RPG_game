using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<string, Inventory> inventoryByName = new Dictionary<string, Inventory>();


    [Header("mainInv")]
    public Inventory mainInv;
    public int mainInvSlotsCount;

    [Header("toolbar")]
    public Inventory toolbar;
    public int toolbarSlotsCount;


    private void Awake()
    {
        mainInv = new Inventory(mainInvSlotsCount);
        toolbar = new Inventory(toolbarSlotsCount);

        inventoryByName.Add("mainInv", mainInv);
        inventoryByName.Add("toolbar", toolbar);

    }

    public void Add(string inventoryName, Item item)
    {
        if (inventoryByName.ContainsKey(inventoryName))
        {
            inventoryByName[inventoryName].Add(item);
        }
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
