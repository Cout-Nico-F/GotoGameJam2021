using UnityEngine;
using Photon.Pun;

public class TextActivator : MonoBehaviour
{
    [SerializeField] private GameObject letterE;
    [SerializeField] private GameObject dialog;

    private PhotonView photonView;

    private bool inRange = false;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            if (inRange)
            {
                letterE.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    dialog.SetActive(true);
                }
            }
            else
            {
                letterE.SetActive(false);
                dialog.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (photonView.IsMine)
        {
            if (collision.CompareTag("Interactuable"))
            {
                inRange = true;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (photonView.IsMine)
        {
            if (collision.CompareTag("Interactuable"))
            {
                inRange = false;
            }
        }
    }
}
