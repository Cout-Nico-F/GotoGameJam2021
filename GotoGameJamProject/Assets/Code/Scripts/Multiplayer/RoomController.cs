using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;

public class RoomController : MonoBehaviour,IPunObservable
{
    [SerializeField] private float minutes;
    [SerializeField] private float seconds;
    [SerializeField] private float minutesGracia;
    [SerializeField] private float secondsGracia;
    [SerializeField] public int goalActual;
    [SerializeField] public int goal;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    bool pv=true;
    void Start()
    {
        textMeshPro.enabled = false;
    }
    private void Update()
    {
        if (minutesGracia >= 0 && secondsGracia > 0)
        {
            secondsGracia -= Time.deltaTime;
            if (secondsGracia <= 0)
            {
                minutesGracia--;
                secondsGracia = 60;
            }
        }
        else
        {
            if(pv)
            {
                goal = 2+ PhotonNetwork.CountOfPlayers*3;
                pv = false;
                Debug.Log(goal);
            }
            textMeshPro.enabled = true;
            textMeshPro.text = minutes + ":" + Mathf.Round(seconds);
            if (minutes >= 0 && seconds > 0)
            {
                seconds -= Time.deltaTime;
                if (seconds <= 0)
                {
                    minutes--;
                    seconds = 60;
                }
            }
            else
            {
                minutes = 0;
                seconds = 0;
                textMeshPro.enabled = false;
                if(goalActual>=goal)
                {///aca ganaron
                    Debug.Log("Equipo ganador!!");
                }
                else
                {///aca perdieron
                    Debug.Log("Equipo perdedor!!");
                }
            }
        }

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(minutes);
            stream.SendNext(seconds);
            stream.SendNext(minutesGracia);
            stream.SendNext(secondsGracia);
            stream.SendNext(goal);
            stream.SendNext(goalActual);
        }
        else
        {
            minutes = (float)stream.ReceiveNext();
            seconds = (float)stream.ReceiveNext();
            minutesGracia = (float)stream.ReceiveNext();
            secondsGracia = (float)stream.ReceiveNext();
            goal = (int)stream.ReceiveNext();
            goalActual = (int)stream.ReceiveNext();
        }
    }
}
