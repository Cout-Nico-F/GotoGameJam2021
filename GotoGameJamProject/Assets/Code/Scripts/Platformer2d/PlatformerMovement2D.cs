using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement2D : MonoBehaviour
{
    /*****Movimiento*****/
    [Header("Movement")]
    [SerializeField]
    float Speed = 0;
    Rigidbody2D rb2d;

    /******Salto********/
    [Header("Jump")]
    [SerializeField]
    float JumpForce;
    [SerializeField]
    float Gravity;
    [SerializeField]
    Vector3 OffsetRaycast;
    [SerializeField]
    float RaycastDistanceJump;
    bool inFloor;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        inFloor = VerifyFloor();
        HorizontalMovement();
        Jump();
    }



    private bool VerifyFloor()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position-OffsetRaycast, Vector2.down, RaycastDistanceJump);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Floor"))
            {return true; }
        }
        return false;
    }

    private void HorizontalMovement()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        Vector2 LateralMovement = new Vector2(Speed*HorizontalInput,0);
        LateralMovement *= Time.deltaTime;
        transform.Translate(LateralMovement);
    }

    private void Jump()
    {
        /**Gravedad**/
        if(!inFloor)
        { rb2d.AddForce(Vector2.down * Time.deltaTime * Gravity); }
        /**Salto**/
        if(Input.GetButton("Jump")&&inFloor)
        {rb2d.AddForce(Vector2.up*Time.deltaTime*JumpForce);}
    }
}
