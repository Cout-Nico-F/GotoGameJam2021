using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTOPDOWN : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    [SerializeField] private float movementSpeed;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement != new Vector2(0, 0))
        { animator.SetBool("run", true); }
        else
        { animator.SetBool("run", false); }
    }
    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
