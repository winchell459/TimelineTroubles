using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<InventoryObject> inventory;

    public bool hasObject(InventoryObject inventoryObject)
    {
        for (int i = 0; i < inventory.Count; i += 1)
        {
            if (inventory[i] == inventoryObject) return true;
        }
        return false;
    }

    public void addObjects(InventoryObject inventoryObject)
    {
        inventory.Add(inventoryObject);
    }
}
