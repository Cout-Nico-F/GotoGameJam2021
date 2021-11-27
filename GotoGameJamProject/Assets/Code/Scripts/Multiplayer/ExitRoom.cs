using UnityEngine;
using Photon.Pun;

public class ExitRoom : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnExitRoom);
    }

    public void OnExitRoom()
    {
        //foreach (var item in AudioJam.SoundManager.instance.sounds)
        //{
        //    if (item.source.isPlaying)
        //    {
        //        AudioJam.SoundManager.instance.Stop(item.name);
        //    }
        //}
        
        PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.LocalPlayer);
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("Loading");
    }
}
