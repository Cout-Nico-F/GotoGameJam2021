using UnityEngine;
using Photon.Pun;
using TMPro;

public class ShowNamePlayer : MonoBehaviour
{
    [SerializeField] private PhotonView photonView;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    private int frames;

    void Update()
    {
        frames++;
        if (frames % 60 == 0)
        {
            if (photonView.IsMine)
            {
                photonView.RPC("ShowName", RpcTarget.All, PhotonNetwork.NickName);
                textMeshProUGUI.text = "";
            }
        }
    }
    [PunRPC]
    public void ShowName(string name)
    {
        textMeshProUGUI.text = name;
    }
}
