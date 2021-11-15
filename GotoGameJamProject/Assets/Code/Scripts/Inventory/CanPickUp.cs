using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventoryJam;

public class CanPickUp : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            if (inventory.HasSpace())
            {
                inventory.AddItem(collision.gameObject.GetComponent<Item>());
                collision.gameObject.SetActive(false);
                Debug.Log("Recogio el item");
            }
            else
            {
                Debug.Log("Inventory Full");
                //Aca podemos usar un sonido y una animacion de movimiento sobre el inventario o un popup peque�o sobre el item.
            }
        }
    }
}
