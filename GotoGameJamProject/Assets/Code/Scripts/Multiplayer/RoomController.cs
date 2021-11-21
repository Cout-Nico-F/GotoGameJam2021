using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class RoomController : MonoBehaviour,IPunObservable
{
    private static RoomController instance;
    public static RoomController Instance => instance; 
    [SerializeField] private float minutes;
    [SerializeField] private float seconds;
    [SerializeField] private float minutesGracia;
    [SerializeField] private float secondsGracia;
    [SerializeField] private int goalActual; 
    [SerializeField] private int goal;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Image image;
    bool pv=true;
    private LevelUI levelUI;

    public float Minutes { get => minutes; set => minutes = value; }
    public float Seconds { get => seconds; set => seconds = value; }
    public float MinutesGracia { get => minutesGracia; set => minutesGracia = value; }
    public float SecondsGracia { get => secondsGracia; set => secondsGracia = value; }
    public int GoalActual { get => goalActual; set => goalActual = value; }
    public int Goal { get => goal; set => goal = value; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Se esta creando una segunda instancia de RoomController");
            //Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        goalActual = 0;
    }
    void Start()
    {
        textMeshPro.enabled = false;
    }
    private void Update()
    {
        image.fillAmount = (float)goalActual / (float)goal;
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
                goal = 2 + PhotonNetwork.CurrentRoom.PlayerCount * 3;
                pv = false;
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
