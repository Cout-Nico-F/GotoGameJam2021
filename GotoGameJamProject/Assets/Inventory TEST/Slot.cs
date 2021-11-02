using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryJam
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private Image itemImageHolder = default;

        protected bool isFree = default;
        private Item item;

        public Item Item { get => item; }

        private void Awake()
        {
            isFree = false;
        }

        public void Insert(Item item)
        {
            this.item = item;
            this.itemImageHolder.sprite = item.Image.sprite;
        }
    }
}
