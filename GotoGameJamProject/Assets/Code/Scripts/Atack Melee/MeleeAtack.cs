using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MeleeAtack : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject player;
    [SerializeField] private Camera cam;
    [SerializeField] private Vector3 offset;
    [SerializeField] private PhotonView photonView;
    private bool isAtack = false;
    private Vector3 dir;
    private float angle;
    private GameObject collisionActual;

    void Update()
    {
        if (photonView.IsMine)
        {
            if (!isAtack)
            {
                RotationAndPosition();
                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine(CorutineAtack());
                }
            }
        }
    }
    private void RotationAndPosition()
    {
        if (!isAtack)
        {
            transform.position = player.transform.position + offset;
            dir = Input.mousePosition - cam.WorldToScreenPoint(transform.position);
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    IEnumerator CorutineAtack()
    {
        isAtack = true;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(dir.x, dir.y, 0), 0.5f);
        yield return new WaitForSeconds(0.05f);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.5f);
        isAtack = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.CompareTag("Pushable") || collision.CompareTag("Player")) && isAtack)
        {
            collisionActual = collision.gameObject;   
            photonView.RPC("Push", RpcTarget.All);
        }
        if(collision.CompareTag("Hittable") && isAtack)
        {
            StartCoroutine(Shake(0.1f, 0.01f,collision));
        }
    }
    [PunRPC]
    public void Push()
    {
        collisionActual.transform.position = Vector3.MoveTowards(collisionActual.transform.position, new Vector3(dir.x, dir.y, 0), 0.5f);
    }
    public IEnumerator Shake(float duration, float magnitude,Collider2D collision)
    {
        Vector3 orignalPosition = collision.transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            collision.transform.position += new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        collision.transform.position = new Vector3(orignalPosition.x,orignalPosition.y,0);
    }
}
