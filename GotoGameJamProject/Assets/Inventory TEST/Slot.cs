using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryJam
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private Image itemImageHolder;

        private bool isFree;
        private Item item;

        public Item Item { get => item; }
        public bool IsFree { get => isFree; }

        private void Awake()
        {
            isFree = true;
        }

        public void Insert(Item item)
        {
            this.item = item;
            this.itemImageHolder.sprite = item.Sprite;
            this.IsFree = false;
        }
    }
}
