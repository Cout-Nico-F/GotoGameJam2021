using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,Interactable
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Collider2D collider2D;
    public void Interact(GameObject gameObject)
    {
        if (spriteRenderer.enabled)
        {
            spriteRenderer.enabled = false;
            collider2D.isTrigger = true;
        }
        else
        {
            spriteRenderer.enabled = true;
            collider2D.isTrigger = false;
        }
    }
}
