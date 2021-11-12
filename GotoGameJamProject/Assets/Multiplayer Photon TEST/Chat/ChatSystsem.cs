using TMPro;
using UnityEngine;
using Photon.Pun;

public class ChatSystsem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private PhotonView photonView;

    public void PlayerTalk(string textPlayerInput)
    {
        photonView.RPC("SyncTextPlayerChat", RpcTarget.All, textPlayerInput); 
    }

    [PunRPC]
    public void SyncTextPlayerChat(string textPlayerInput)
    {
        textMesh.text = textMesh.text + "\n" + textPlayerInput;
    }
}
