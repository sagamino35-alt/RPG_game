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


    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Setup();
        }
        else
        {
            inventoryPanel.SetActive(false);
            
        }



    }

    void Setup()
    {
        if (slots.Count == player.inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].type != CollectableType.NONE)
                {
                    
                }
                else
                {
                    
                }
            }
        }
    }


}
