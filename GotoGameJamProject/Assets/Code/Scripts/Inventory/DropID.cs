using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace InventoryJam
{
    public class DropID : MonoBehaviour,IPointerDownHandler
    {
        [SerializeField] Inventory inventory;

        public void OnPointerDown(PointerEventData eventData)
        {
            inventory.DropItem(int.Parse(gameObject.name));
        }
    }
}