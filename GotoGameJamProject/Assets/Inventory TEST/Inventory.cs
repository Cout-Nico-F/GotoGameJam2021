using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryJam
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] Slot[] slots = default;

        private void AddItem(Item item)
        {
            FindSlot().Insert(item);
        }
        
        private void RemoveItem(Item item)
        {
            
        }
        
        private bool HasSpace()
        {
            return false;
        }

        private Slot FindSlot()
        {
            return new Slot();
        }
    }

}