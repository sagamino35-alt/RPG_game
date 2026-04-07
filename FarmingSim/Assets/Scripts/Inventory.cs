using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour
{
    [System.Serializable]
    public class Slot
    {

        public CollectableType type;

        public int count;
        public int maxCount;

        public Sprite icon;
        public Slot()
        {
            type = CollectableType.NONE;
            count = 0;
            maxCount = 99;
        }

        public bool CanAddItem()
        {
            if (count < maxCount)
            {
                return true;
            }

            return false;
        }

        public void AddItem(PickUp item)
        {
            this.type = item.type;
            this.icon = item.icon;
            count++;
        }


    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots)
    {
        for(int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }


    }


    public void Add(PickUp item)
    {
        foreach(Slot slot in slots)
        {
            if (slot.type == item.type && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }

        foreach(Slot slot in slots)
        {
            if (slot.type == CollectableType.NONE)
            {
                slot.AddItem(item);
                return;
            }
        }


    }

}
