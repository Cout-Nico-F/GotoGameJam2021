using TMPro;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class ChatSystsem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private PhotonView photonView;
    [SerializeField] private Scrollbar scrollBar;

    public void PlayerTalk(string textPlayerInput)
    {
        photonView.RPC("SyncTextPlayerChat", RpcTarget.All, textPlayerInput, PhotonNetwork.NickName);
    }

    [PunRPC]
    public void SyncTextPlayerChat(string textPlayerInput, string name)
    {
        scrollBar.value = -0.5f;
        textMesh.text = textMesh.text + "\n" + name + ": " + textPlayerInput;
    }
}
