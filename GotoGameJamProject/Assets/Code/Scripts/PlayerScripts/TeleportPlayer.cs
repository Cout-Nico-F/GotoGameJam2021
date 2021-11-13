using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TeleportJam
{
    public class TeleportPlayer : MonoBehaviour
    {
        public void Teleport(GameObject player)
        {
           player.transform.position = transform.position;
        }
    }
}
