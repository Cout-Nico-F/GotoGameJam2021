using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryJam
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] Slot[] slots = default;

        public event Action<string> OnPickedItem;


        public void AddItem(Item item)
        {
            FindNextEmptySlot().Insert(item);
            OnPickedItem?.Invoke(item.Id);
        }

        public void DropItem(int ID)
        {
            slots[ID].Drop();
        }

        public void RemoveItems(string id, int amount)
        {
            Debug.Log("Entra a quitar " + amount + " " + id);
            var firstSlot = -1;

            // encontramos el primer slot que tiene ese item
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].Item.Id.Equals(id))
                {
                    firstSlot = i;
                    Debug.Log("Primer slot con el item: " + firstSlot);
                    break;
                }
            }

            // si no hemos encontrado el item damos error
            if (firstSlot == -1)
            {
                Debug.LogError("Item " + id + " no encontrado en el inventario");
                return;
            }

            // si lo hemos encontrado lo eliminamos y movemos hacia la izquierda los items
            // para no dejar huecos
            slots[firstSlot].Remove();
            MoveItemsToLeft(firstSlot);
        }


        private void MoveItemsToLeft(int emptySlot)
        {
            Debug.Log("Move Items To Left: " + emptySlot);
            var remainingItems = slots.Length - emptySlot - 1;
            Debug.Log("Remaining items: " + remainingItems);
            var currentSlot = emptySlot + 1;

            while (remainingItems > 0)
            {
                if (!slots[currentSlot].IsFree)
                {
                    var itemToMove = slots[currentSlot].Item;
                    slots[emptySlot].Insert(itemToMove);
                    slots[currentSlot].Remove();
                    emptySlot++;
                }

                currentSlot++;
                remainingItems--;
            }
        }


        public bool HasSpace()
        {
            foreach (var slot in slots)
            {
                if (slot.IsFree)
                {
                    return true;
                }
            }
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