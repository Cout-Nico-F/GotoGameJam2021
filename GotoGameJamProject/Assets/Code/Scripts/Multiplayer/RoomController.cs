using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    bool firstTime = true;
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
        firstTime = true;
    }
    void Start()
    {
        textMeshPro.enabled = false;
    }
    private void Update()
    {
        if(goal != 0)
        {
            image.fillAmount = (float)goalActual / (float)goal;
        }

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
            if(firstTime)
            {
                goal = 2 + PhotonNetwork.CurrentRoom.PlayerCount * 3;
                firstTime = false;
                textMeshPro.enabled = true;
            }

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
                if(goalActual >= goal)
                {///aca ganaron
                    StartCoroutine(Disconnect("WinGame"));
                    
                }
                else
                {///aca perdieron{
                    StartCoroutine(Disconnect("LoseGame"));
                } 
            }
        }
    }
    IEnumerator Disconnect(string input)
    {
        PhotonNetwork.Disconnect();
        while (PhotonNetwork.IsConnected)
        {
            yield return null;
            Debug.Log("Disconnecting. . .");
        }
        Debug.Log("DISCONNECTED!");
        SceneManager.LoadScene(input);
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
