using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingCrosshair : MonoBehaviour
{
    [Header("Enter Objects")]
    [SerializeField] private GameObject player;
    [SerializeField] private Camera mainCarmera;
    [Header("Settings")]
    [SerializeField] private float aimRange;

    void Update()
    {
        transform.rotation=Quaternion.Euler(0,0,0);
        Vector2 mousePosition = mainCarmera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
        Vector2 playerPosition = player.transform.position;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, playerPosition.x - aimRange, playerPosition.x + aimRange),
                                        Mathf.Clamp(transform.position.y, playerPosition.y - aimRange, playerPosition.y + aimRange));
    }
}
