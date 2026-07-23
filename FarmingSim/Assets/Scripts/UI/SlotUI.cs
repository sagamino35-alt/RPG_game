using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour
{
    public int slotID;
    public Image itemIcon;
    public TextMeshProUGUI itemAmountText;

    [SerializeField] private GameObject highlight;

    public Inventory inventory;

    public void SetItem(Inventory.Slot slot)
    {
        if (slot != null)
        {
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1);
            itemAmountText.text = slot.count.ToString();
        }
        
    }

    public void SetEmpty()
    {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
        itemAmountText.text = "";
    }

    public void SetHighlight(bool isOn)
    {
        highlight.SetActive(isOn);

    }

}
