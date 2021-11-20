using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovementTOPDOWN : MonoBehaviourPun, IPunObservable
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private GameObject cam;
    public PhotonView photonView;
    private Rigidbody2D rb2d;
    private Animator animator;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    private bool isTalking;
    private bool isChating = false;
    [SerializeField] private GameObject bubbleChat;

    public Vector2 Movement { get => movement; }
    public bool IsTalking { get => isTalking; set => isTalking = value; }
    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    public bool IsChating { get => isChating; set => isChating = value; }

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        photonView = GetComponent<PhotonView>();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

    void Update()
    {
        if (!photonView.IsMine)
        { Destroy(cam); }
        if (photonView.IsMine)
        {
            if (!isTalking || !isChating)
            {
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");
                
                if (!isTalking)
                {
                    cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
                }
            }
            if(isTalking || IsChating)
            {
                movement = Vector2.zero;
                if (isTalking)
                {
                    cam.transform.position = new Vector3(transform.position.x, transform.position.y, -5);
                }
            }
            if(!IsChating)
            {
                photonView.RPC("SetActiveBubbleChat", RpcTarget.All, false);
            }
            else
            {
                photonView.RPC("SetActiveBubbleChat", RpcTarget.All, true);
            }
            ControlAnimaciones();
        }
    }
    [PunRPC]
    public void SetActiveBubbleChat(bool state)
    {
        bubbleChat.SetActive(state);
    }

    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            //rb2d.MovePosition(rb2d.position + movement * movementSpeed * Time.fixedDeltaTime);
            rb2d.velocity = new Vector2(movement.x * movementSpeed, movement.y * movementSpeed);
        }
    }

    private void ControlAnimaciones()
    {
        animator.SetFloat("velocity", movement.sqrMagnitude);
        if (movement.x < 0)
        { photonView.RPC("FlipCharacter", RpcTarget.All, true); }
        if (movement.x > 0)
        { photonView.RPC("FlipCharacter", RpcTarget.All, false); }
    }

    [PunRPC]
    public void FlipCharacter(bool value)
    {
        spriteRenderer.flipX = value;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PhotonView>() != null)
        {
            collision.gameObject.GetComponent<PhotonView>().TransferOwnership(photonView.Owner);
        }
    }
}
