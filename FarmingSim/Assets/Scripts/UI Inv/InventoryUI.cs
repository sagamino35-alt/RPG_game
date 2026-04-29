using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    InputAction ExitInv;

    public Player player;

    public List<SlotUI> slots = new List<SlotUI>();

    private void Start()
    {
        inventoryPanel.SetActive(false);
        ExitInv = InputSystem.actions.FindAction("ExitUI");
    }

    void Update()
    {
        if (ExitInv.WasPerformedThisFrame())
        {
            
            ToggleInventory();
        }
    }

    private void FixedUpdate()
    {
        Refresh();
    }

    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Refresh();
        }
        else
        {
            inventoryPanel.SetActive(false);
            
        }



    }

    void Refresh()
    {
        if (slots.Count == player.inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].itemName != "")
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    public void Remove(int slotID)
    {

        Item itemToDrop = GameManager.instance.itemManager.GetItemByName(player.inventory.slots[slotID].itemName);

        if (itemToDrop != null)
        {
            player.DropItem(itemToDrop);
            
            player.inventory.Remove(slotID);
            Refresh();
        }
        
    }
}
