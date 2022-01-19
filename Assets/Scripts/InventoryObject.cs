using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour
{
    private bool inInventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!inInventory && collision.CompareTag("Player"))
        {
            inInventory = true;
            FindObjectOfType<Inventory>().addObjects(this);
        }

    }
}
