using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryJam
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private Image itemImageHolder;
        [SerializeField] private GameObject player;

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
            this.isFree = false;
        }
        public void Drop()
        {
            if (this.item != null)
            {
                var obj=Instantiate(this.item, player.transform.position - new Vector3(0, 2, 0), Quaternion.identity);
                obj.gameObject.SetActive(true);
                this.item = null;
                this.itemImageHolder.sprite = null;
                this.isFree = true;
            }
        }
    }
}
