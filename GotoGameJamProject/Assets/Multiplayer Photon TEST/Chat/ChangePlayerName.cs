using UnityEngine;
using Photon.Pun;

public class ChangePlayerName : MonoBehaviour
{
    public void ChangeNamePlayer(string input)
    {
        PhotonNetwork.NickName = input;
    }
}