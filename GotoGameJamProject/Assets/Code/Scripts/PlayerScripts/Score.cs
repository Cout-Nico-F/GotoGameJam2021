using UnityEngine;
using Photon.Pun;
public class Score : MonoBehaviour,IPunObservable
{
    [SerializeField] private int playerScore;
    public int PlayerScore { get => playerScore; set => playerScore = value; }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(PlayerScore);
        }
        else
        {
            PlayerScore = (int)stream.ReceiveNext();
        }
    }
}
