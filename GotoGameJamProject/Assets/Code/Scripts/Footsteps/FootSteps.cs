using UnityEngine;
using Photon.Pun;
public class FootSteps : MonoBehaviour
{
    [SerializeField] private PlayerMovementTOPDOWN playerMovement;
    [SerializeField] private AudioSource stepAudio;
    [SerializeField] private PhotonView photonView;

    private void Update()
    {
        if (playerMovement.Movement.x != 0 || playerMovement.Movement.y != 0)
        {
            if (!stepAudio.isPlaying)
            {
                stepAudio.pitch  = Random.Range(1.95f, 2.4f);
                photonView.RPC("PlayStepSound", RpcTarget.All);
            }
        }
    }
    [PunRPC]
    public void PlayStepSound()
    {
        stepAudio.Play();
    }
}
