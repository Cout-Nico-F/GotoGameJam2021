using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TeleportJam
{
    public class TeleportInput : MonoBehaviour
    {
        [Header("Enter Objects")]
        [SerializeField] private GameObject player;
        [SerializeField] private Camera mainCarmera;
        [SerializeField] private TeleportPlayer tpPLayer;
        [SerializeField] private ParticleSystem teleportParticles;

        [Header("Teleport Settings")]
        [SerializeField] private float teleportRange;
        [SerializeField] private float maxTeleportTimer;
        private float teleportTimer=0;
        private bool teleportCollider=true;
        private bool canTeleport=true;

        void Update()
        {
            Vector2 mousePosition = mainCarmera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition;
            Vector2 playerPosition = player.transform.position;
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, playerPosition.x - teleportRange, playerPosition.x + teleportRange),
                                            Mathf.Clamp(transform.position.y, playerPosition.y - teleportRange, playerPosition.y + teleportRange));
           
            if (!teleportCollider && canTeleport && Input.GetMouseButtonDown(0))
            { teleportParticles.Play(); tpPLayer.Teleport(player);canTeleport = false;}

            if (!canTeleport)
            {
                if(teleportTimer<maxTeleportTimer)
                { teleportTimer += Time.deltaTime; }
                else
                { canTeleport = true;teleportTimer = 0;}
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        { teleportCollider = true; }
        private void OnTriggerExit2D(Collider2D collision)
        { teleportCollider = false; }
    }
}