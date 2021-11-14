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
        if ((collision.CompareTag("Hittable") || collision.CompareTag("Player")) && isAtack)
        {
            collision.transform.position = Vector3.MoveTowards(collision.transform.position, new Vector3(dir.x, dir.y, 0), 0.5f);
        }
    }
}
