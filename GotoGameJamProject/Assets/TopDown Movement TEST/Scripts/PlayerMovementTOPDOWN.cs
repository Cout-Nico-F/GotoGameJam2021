using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovementTOPDOWN : MonoBehaviour, IPunObservable
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private GameObject cam;
    public PhotonView photonView;
    private Rigidbody2D rb2d;
    private Animator animator;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;

    public Vector2 Movement { get => movement; }

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
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            ControlAnimaciones();
        }
    }

    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            rb2d.MovePosition(rb2d.position + movement * movementSpeed * Time.fixedDeltaTime);
        }
    }

    private void ControlAnimaciones()
    {
        animator.SetFloat("velocity",movement.sqrMagnitude);
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
}
