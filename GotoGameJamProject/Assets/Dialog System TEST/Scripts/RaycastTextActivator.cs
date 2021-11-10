
using UnityEngine;
using Photon.Pun;

public class RaycastTextActivator : MonoBehaviour
{
    [Header("Enter objects")]
    [SerializeField] private GameObject e_Letter;

    [Header("Setting")]
    [SerializeField] private float rayRadius;//used for assigning length to raycast

    private Collider2D[] myObjectsHit = default;
    private Interactable? myObjectsHitResult;
    private PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            if (Time.frameCount % 3 == 0)//runs these functions every three frames to save cpu cycles
            {
                myObjectsHit = null;

                myObjectsHit = Physics2D.OverlapCircleAll(transform.position, rayRadius);
                myObjectsHitResult = GetInteractable();
                //cual es interactuable? ++por ahora el dev se encarga de que nunca halla 2 interactuables juntos
            }
            if (myObjectsHitResult != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    myObjectsHitResult.Interact();//run function here
                }
            }
        }
    }
    Interactable? GetInteractable()
    {
        foreach (var o in myObjectsHit)
        {
            if (o.transform.gameObject.GetComponent<Interactable>() != null)
            {
                e_Letter.SetActive(true);
                return o.gameObject.GetComponent<Interactable>();
            }
            else
            {
                e_Letter.SetActive(false);
            }
        }
        return null;
    }
}
