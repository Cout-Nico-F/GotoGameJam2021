using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovementTOPDOWN : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private PhotonView photonView;
    private Rigidbody2D rb2d;
    private Animator animator;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            ControlAnimaciones();
    }
    private void FixedUpdate()
    {
            rb2d.MovePosition(rb2d.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
    private void ControlAnimaciones()
    {
        animator.SetFloat("velocity",movement.sqrMagnitude);
        if (movement.x < 0)
        { spriteRenderer.flipX = true; }
        if (movement.x > 0)
        { spriteRenderer.flipX = false; }
    }
}
