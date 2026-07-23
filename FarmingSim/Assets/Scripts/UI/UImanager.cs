using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public List<InventoryUI> inventoryUIs;
    public Dictionary<string, InventoryUI> inventoryUIbyName = new Dictionary<string, InventoryUI>();

    public SlotUI draggedSlot;
    public Image draggedIcon;

    private void Awake()
    {
        Initialize();
    }
    public InventoryUI GetInventoryUI(string inventoryName)
    {
        if (inventoryUIbyName.ContainsKey(inventoryName))
        {
            return inventoryUIbyName[inventoryName];
        }
        
        Debug.LogWarning("No inventory UI found with name: " + inventoryName);
        return null;
    }

    private void Initialize()
    {
        foreach (InventoryUI ui in inventoryUIs)
        {
            if (!inventoryUIbyName.ContainsKey(ui.inventoryName))
            {
                inventoryUIbyName.Add(ui.inventoryName, ui);
            }
            
        }
    }


}
