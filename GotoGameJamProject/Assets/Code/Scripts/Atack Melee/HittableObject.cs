using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HittableObject : MonoBehaviour, IPunObservable
{
    [SerializeField] PhotonView photonView;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite spriteDead;
    [SerializeField] int amountDroped;
    [SerializeField] GameObject item;
    public int life=3;
    private bool dropOnlyOnce=false;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(life);
        }
        else
        {
            life = (int)stream.ReceiveNext();
        }
    }

    void Update()
    {
        if(dropOnlyOnce==false)
        {
            if (life <= 0)
            {
                var colliders = GetComponents<BoxCollider2D>();
                if (colliders != null)
                {
                    foreach (var item in colliders)
                    {
                        item.enabled = false;
                    }
                }
                photonView.RPC("DropAndDead", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    public void DropAndDead()
    {
        dropOnlyOnce = true;
        spriteRenderer.sprite = spriteDead;
        for (int i = 0; i < amountDroped; i++)
        {
            if (item != null )
            {
                Instantiate(item, transform.position + new Vector3(Random.value, Random.value, 0), Quaternion.identity);
            }
        }
    }
}
