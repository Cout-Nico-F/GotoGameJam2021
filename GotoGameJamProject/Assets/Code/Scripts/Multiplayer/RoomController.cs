using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour, IPunObservable
{
    private static RoomController instance;
    public static RoomController Instance => instance;
    [SerializeField] public float minutesGracia;
    [SerializeField] public float secondsGracia;
    [SerializeField] public int goalActual;
    [SerializeField] public int goal;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Image image;
    bool firstTime = true;
    private LevelUI levelUI;

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
        AudioJam.SoundManager.instance.Stop("Tema3");
    }
    private void Update()
    {
        if (goalActual >= goal)
        {///aca ganaron
            StartCoroutine(Disconnect("WinGame"));
        }

        if (goal != 0)
        {
            image.fillAmount = (float)goalActual / (float)goal;
        }
        string minutesText;
        string secondsText;
        if (Mathf.Round(minutesGracia) <10)
        {
            minutesText ="0"+minutesGracia.ToString();
        }
        else
        {
            minutesText = minutesGracia.ToString();
        }
        if (Mathf.Round(secondsGracia) < 10)
        {
            secondsText = "0" + Mathf.Round(secondsGracia).ToString();
        }
        else
        {
            secondsText = Mathf.Round(secondsGracia).ToString();
        }
        textMeshPro.text = minutesText + ":" + secondsText;
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
            if (goalActual >= goal)
            {///aca ganaron
                StartCoroutine(Disconnect("WinGame"));
            }
            else
            {///aca perdieron{
                StartCoroutine(Disconnect("LooseGame"));
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
        if (stream.IsWriting)
        {
            stream.SendNext(minutesGracia);
            stream.SendNext(secondsGracia);
            stream.SendNext(goal);
            stream.SendNext(goalActual);
        }
        else
        {
            minutesGracia = (float)stream.ReceiveNext();
            secondsGracia = (float)stream.ReceiveNext();
            goal = (int)stream.ReceiveNext();
            goalActual = (int)stream.ReceiveNext();
        }
    }
}
