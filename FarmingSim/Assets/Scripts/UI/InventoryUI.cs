using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    InputAction ExitInv;

    public string inventoryName;

    public List<SlotUI> slots = new List<SlotUI>();


    [SerializeField] private Canvas canvas;
    private SlotUI draggedSlot;
    private Image draggedIcon;
    private bool dragSingle;

    private Inventory inventory;

    private void Awake()
    {
        canvas = FindAnyObjectByType<Canvas>();
    }
    private void Start()
    {
        
        inventory = 
        SetUpSlots();

        ExitInv = InputSystem.actions.FindAction("ExitUI");
        inventoryPanel.SetActive(false);
        Refresh();
        

    }

    void Update()
    {
        if (ExitInv.WasPerformedThisFrame())
        {
            
            ToggleInventory();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            dragSingle = true;
        }
        else
        {
            dragSingle = false;
        }

    }

    private void FixedUpdate()
    {
        Refresh();
    }

    public void ToggleInventory()
    {
        if (inventoryPanel != null) 
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
        else if (slots.Count == player.toolbar.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (player.toolbar.slots[i].itemName != "")
                {
                    slots[i].SetItem(player.toolbar.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    public void Remove()
    {

        Item itemToDrop = GameManager.instance.itemManager.GetItemByName(player.inventory.slots[draggedSlot.slotID].itemName);

        if (itemToDrop != null)
        {
            if (dragSingle == true)
            {
                player.DropItem(itemToDrop);
                player.inventory.Remove(draggedSlot.slotID);
            }
            else
            {
                player.DropItem(itemToDrop, player.inventory.slots[draggedSlot.slotID].count);
                player.inventory.Remove(draggedSlot.slotID, player.inventory.slots[draggedSlot.slotID].count);
            }
            
            Refresh();
        }
        
        draggedSlot = null;
    }

    public void SlotBeginDrag(SlotUI slot)
    {
        

        draggedSlot = slot;
        draggedIcon = Instantiate(draggedSlot.itemIcon);
        draggedIcon.transform.SetParent(canvas.transform);
        draggedIcon.raycastTarget = false;

        
        draggedIcon.rectTransform.sizeDelta = new Vector2(80,80);
        MoveToMousePos(draggedIcon.gameObject);
    }

    public void SlotDrag()
    {
        MoveToMousePos(draggedIcon.gameObject);

    }

    public void SlotEndDrag()
    {
        Destroy(draggedIcon.gameObject);
        draggedIcon = null;
    }

    public void SlotDrop(SlotUI slot)
    {
        player.inventory.MoveSlot(draggedSlot.slotID, slot.slotID);
        Refresh();
    }


    private void MoveToMousePos(GameObject toMove)
    {
        if (canvas != null)
        {
            Vector2 pos;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, 
                Input.mousePosition, null, out pos);

            toMove.transform.position = canvas.transform.TransformPoint(pos);
        }
    }

    private void SetUpSlots()
    {
        int counter = 0;

        foreach(SlotUI slot in slots)
        {
            slot.slotID = counter;
            counter++;

        }

    }



}

