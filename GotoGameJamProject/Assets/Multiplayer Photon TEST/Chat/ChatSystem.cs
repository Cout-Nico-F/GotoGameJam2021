using Photon.Pun;
using UnityEngine;


public class ChatSystem : MonoBehaviour
{
    [Header("Enter parameters")]
    [SerializeField] private TextFramePlayer textFramePayer;
    [SerializeField] private PhotonView photonView;
    private void Start()
    {
        if (!photonView.IsMine)
        { gameObject.SetActive(false); }
    }
    public void ReadInptPlayer(string s)
    {
        textFramePayer.gameObject.SetActive(true);
        textFramePayer.StartCoroutine(textFramePayer.PlayerTalk(s));
    }
}
