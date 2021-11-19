using UnityEngine;
using Photon.Pun;

public class Radio : MonoBehaviour, Interactable
{
    public AudioSource audioSource;
    public PhotonView photonView;
    private bool isPlaying;
    public void Interact(GameObject gameObject)
    {
        photonView.RPC("PlayAndStopMusic", RpcTarget.All);
    }
    [PunRPC]
    public void PlayAndStopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }
}
