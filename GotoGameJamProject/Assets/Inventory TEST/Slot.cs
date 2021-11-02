using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryJam
{
    public class Slot : MonoBehaviour
    {
        protected bool isFree = default;

        private void Awake()
        {
            isFree = false;
        }

        public void Insert(Item item)
        {

        }
    }
}
