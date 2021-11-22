using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MeleeAtack : MonoBehaviourPun
{
    [Header("Settings")]
    [SerializeField] private GameObject player;
    [SerializeField] private Camera cam;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float offset2;
    [SerializeField] private PhotonView photonView;
    [SerializeField] private GameObject minePlayer;
    [SerializeField] private Animator animator;
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
            transform.position = player.transform.position + offset;
            dir = Input.mousePosition - cam.WorldToScreenPoint(player.transform.localPosition);
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(0,0,angle+offset2);
    }
    IEnumerator CorutineAtack()
    {
        animator.SetBool("punch", true);
        isAtack = true;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(dir.x, dir.y, 0), 0.5f);
        yield return new WaitForSeconds(0.05f);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.5f);
        isAtack = false;
        animator.SetBool("punch", false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.CompareTag("Pushable") || collision.CompareTag("Player")) && isAtack && collision.gameObject!=minePlayer)
        {
            collision.GetComponent<PhotonView>().TransferOwnership(photonView.Owner);
            //collision.transform.position = Vector3.MoveTowards(collision.transform.position, new Vector3(dir.x, dir.y, 0), 0.5f);
            collision.GetComponent<Rigidbody2D>().AddForce(dir*2);
        }
        if (collision.CompareTag("Hittable") && isAtack)
        {
            if (collision.GetComponent<HittableObject>().life > 0)
            {
                StartCoroutine(Shake(0.1f, 0.05f, collision));
                collision.gameObject.GetComponent<HittableObject>().life--;
            }
        }
    }

    public IEnumerator Shake(float duration, float magnitude, Collider2D collision)
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
        collision.transform.position = new Vector3(orignalPosition.x, orignalPosition.y, 0);
    }
}
