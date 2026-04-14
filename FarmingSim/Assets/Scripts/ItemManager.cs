using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public PickUp[] collectableItems;

    private Dictionary<CollectableType, PickUp> collectableItemsDict = new Dictionary<CollectableType, PickUp>();


    private void Awake()
    {
        foreach (PickUp item in collectableItems)
        {
            AddItem(item);
        }
    }


    private void AddItem(PickUp item)
    {
        if (!collectableItemsDict.ContainsKey(item.type))
        {
            collectableItemsDict.Add(item.type, item);
        }
    }

    public PickUp GetItemByType(CollectableType type)
    {
        if (collectableItemsDict.ContainsKey(type))
        {
            return collectableItemsDict[type];
        }

        return null;
    }
}
