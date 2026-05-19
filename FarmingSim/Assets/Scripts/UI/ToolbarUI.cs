using System.Collections.Generic;
using UnityEngine;

public class ToolbarUI : MonoBehaviour
{
    [SerializeField] private List<SlotUI> Tslots = new List<SlotUI>();

    private SlotUI selectedSlot;

    private void Start()
    {
        SelectTBslot(0);
    }
    private void Update()
    {
        CheckANkeys();
    }

    public void SelectTBslot(int index)
    {
        if (Tslots.Count == 9)
        {
            if (selectedSlot != null)
            {
                selectedSlot.SetHighlight(false);
            }
            selectedSlot = Tslots[index];
            selectedSlot.SetHighlight(true);
            Debug.Log("Selected slot: " + selectedSlot.name);
        }
    }

    private void CheckANkeys()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectTBslot(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectTBslot(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectTBslot(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectTBslot(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectTBslot(4);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SelectTBslot(5);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SelectTBslot(6);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SelectTBslot(7);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SelectTBslot(8);
        }
    }

}
