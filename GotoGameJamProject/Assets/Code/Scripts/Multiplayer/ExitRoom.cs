using UnityEngine;
using Photon.Pun;

public class ExitRoom : MonoBehaviour
{
    public void exitRoom()
    {
        PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.LocalPlayer);
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("Loading");
    }
}
