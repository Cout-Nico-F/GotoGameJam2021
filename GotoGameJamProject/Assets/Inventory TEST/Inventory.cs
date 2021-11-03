using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryJam
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] Slot[] slots = default;

        public void AddItem(Item item)
        {
            FindNextEmptySlot().Insert(item);
        }

        public void RemoveItem(Item item)
        {
            
        }

        public bool HasSpace()
        {
            return false;
        }

        private Slot FindNextEmptySlot()
        {
            foreach (var s in slots)
            {
                if (s.IsFree)
                {
                    return s;
                }
            }
            Debug.LogError("FindNextEmptySlot needs to be called on a non-full inventory!");
            return new Slot();
        }
    }

}