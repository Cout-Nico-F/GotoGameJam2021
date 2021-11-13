using TMPro;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ChatSystsem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private PhotonView photonView;

    public void PlayerTalk(string textPlayerInput)
    {
        photonView.RPC("SyncTextPlayerChat", RpcTarget.All, textPlayerInput, PhotonNetwork.NickName);
    }

    [PunRPC]
    public void SyncTextPlayerChat(string textPlayerInput, string name)
    {
        textMesh.text = textMesh.text + "\n" + name + ": " + textPlayerInput;
    }
}
