using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTOPDOWN : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animator;
    [SerializeField] private float movementSpeed;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (movement != new Vector2(0, 0))
        { animator.SetBool("run", true); }
        else
        { animator.SetBool("run", false); }
        if (movement.x < 0)
        { spriteRenderer.flipX = true; }
        if (movement.x > 0)
        { spriteRenderer.flipX = false; }
    }
}
