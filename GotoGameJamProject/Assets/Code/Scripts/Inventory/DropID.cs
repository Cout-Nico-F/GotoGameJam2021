using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryJam
{
    public class DropID : MonoBehaviour
    {
        [SerializeField] Inventory inventory;
        public void Drop()
        {
            inventory.RemoveItem(int.Parse(gameObject.name));
        }
    }
}