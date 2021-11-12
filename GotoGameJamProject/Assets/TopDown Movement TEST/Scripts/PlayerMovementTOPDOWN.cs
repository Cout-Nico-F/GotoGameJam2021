using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovementTOPDOWN : MonoBehaviour, IPunObservable
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Camera cam;
    public PhotonView photonView;
    private Rigidbody2D rb2d;
    private Animator animator;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;

    public Vector2 Movement { get => movement; }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        photonView = GetComponent<PhotonView>();
        if(!photonView.IsMine)
        { cam.enabled = false; }
        AddObservable();
    }
    private void AddObservable()
    {
        if (!photonView.ObservedComponents.Contains(this))
        {
            photonView.ObservedComponents.Add(this);
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(spriteRenderer.flipX);
        }
        else
        {
            spriteRenderer.flipX = (bool)stream.ReceiveNext();
        }
    }
    void Update()
    {
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
        { spriteRenderer.flipX = true; }
        if (movement.x > 0)
        { spriteRenderer.flipX = false; }
    }
}
