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
            inventory.DropItem(int.Parse(gameObject.name));
        }
    }
}