using UnityEngine;
using Photon.Pun;
public class Score : MonoBehaviour,IPunObservable
{
    [HideInInspector] public int playerScore;
    public int PlayerScore { get => playerScore; set => playerScore = value; }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(playerScore);
        }
        else
        {
            playerScore = (int)stream.ReceiveNext();
        }
    }
}
