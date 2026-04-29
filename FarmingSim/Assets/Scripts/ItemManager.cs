using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Item[] items;

    private Dictionary<string, Item> nameOfItemDict = new Dictionary<string, Item>();


    private void Awake()
    {
        foreach (Item item in items)
        {
            AddItem(item);
        }
    }


    private void AddItem(Item item)
    {
        if (!nameOfItemDict.ContainsKey(item.data.itemName))
        {
            nameOfItemDict.Add(item.data.itemName, item);
        }
    }

    public Item GetItemByName(string key)
    {
        if (nameOfItemDict.ContainsKey(key))
        {
            return nameOfItemDict[key];
        }

        return null;
    }
}
