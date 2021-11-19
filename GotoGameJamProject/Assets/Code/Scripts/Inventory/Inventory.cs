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
        public event Action<string> OnDropItem;


        public void AddItem(Item item)
        {
            FindNextEmptySlot().Insert(item);
            OnPickedItem?.Invoke(item.Id);
        }

        public void DropItem(int ID)
        {
            // tenemos que actualizar la quest UI
            OnDropItem?.Invoke(slots[ID].Item.Id);

            slots[ID].Drop();
            MoveItemsToLeft(ID);
        }

        public void RemoveItems(string id, int amount)
        {
            while (amount > 0)
            {
                var firstSlot = -1;

                // encontramos el primer slot que tiene ese item
                for (int i = 0; i < slots.Length; i++)
                {
                    if (slots[i].Item.Id.Equals(id))
                    {
                        firstSlot = i;
                        break;
                    }
                }

                // si no hemos encontrado el item damos error
                if (firstSlot == -1)
                {
                    Debug.LogError("Item " + id + " no encontrado en el inventario, y faltaban por quitar " + amount);
                    return;
                }

                // si lo hemos encontrado lo eliminamos y movemos hacia la izquierda los items
                // para no dejar huecos
                slots[firstSlot].Remove();
                MoveItemsToLeft(firstSlot);
                amount--;
            }
        }


        private void MoveItemsToLeft(int emptySlot)
        {
            var remainingItems = slots.Length - emptySlot - 1;
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