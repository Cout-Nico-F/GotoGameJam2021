using UnityEngine;
using Photon.Pun;

public class ChangePlayerName : MonoBehaviour
{
    private void Awake()
    {
        PhotonNetwork.NickName = "PLAYER";
    }
    public void ChangeNamePlayer(string input)
    {
        PhotonNetwork.NickName = input;
    }
}