using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventoryJam;

public class CanPickUp : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            inventory.AddItem(collision.gameObject.GetComponent<Item>());
            collision.gameObject.SetActive(false);
        }
    }
}
