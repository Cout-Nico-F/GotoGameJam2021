using UnityEngine;
using Photon.Pun;

public class RaycastTextActivatorJavi : MonoBehaviour
{
    [Header("Enter objects")]
    [SerializeField] private GameObject e_Letter;

    [Header("Setting")]
    [SerializeField] private float rayRadius;//used for assigning length to raycast

    private Collider2D[] myObjectsHit = default;
#nullable enable
    private IInteractable? myObjectsHitResult;
#nullable disable
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
                    myObjectsHitResult.Interact(this.gameObject);//run function here
                }
            }
        }
    }
#nullable enable
    IInteractable? GetInteractable()
    {
        foreach (var o in myObjectsHit)
        {
            if (o.transform.GetComponent<IInteractable>() != null)
            {
                e_Letter.SetActive(true);
                return o.transform.GetComponent<IInteractable>();
            }
            else
            {
                e_Letter.SetActive(false);
            }
        }
        return null;
    }
#nullable disable
}
