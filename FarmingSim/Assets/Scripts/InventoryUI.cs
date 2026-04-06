using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    InputAction ExitInv;

    private void Start()
    {
        ExitInv = InputSystem.actions.FindAction("ExitUI");
    }

    void Update()
    {
        if (ExitInv.WasPerformedThisFrame())
        {
            Debug.Log("Closed Inv");
            ToggleInventory();
        }
    }


    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
        }
        else
        {
            inventoryPanel.SetActive(false);
        }



    }

}
