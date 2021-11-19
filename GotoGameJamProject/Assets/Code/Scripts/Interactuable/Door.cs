using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Door : MonoBehaviour, Interactable,IPunObservable
{
    public SpriteRenderer spriteRenderer;
    public Collider2D collider2D;
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

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(spriteRenderer.enabled);
            stream.SendNext(collider2D.isTrigger);
        }
        else
        {
            spriteRenderer.enabled = (bool)stream.ReceiveNext();
            collider2D.isTrigger = (bool)stream.ReceiveNext();
        }
    }
}
