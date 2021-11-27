
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class LobbyUI : MonoBehaviourPunCallbacks
{
    [SerializeField] private Button btn_Create;
    [SerializeField] private Button btn_Join;
    [SerializeField] private Button btn_Exit;
    [SerializeField] private string loadLevelString;

    [SerializeField] private InputField createInput;
    [SerializeField] private InputField joinInput;

    private void Awake()
    {
        btn_Create.onClick.AddListener(CreateRoom);
        btn_Join.onClick.AddListener(JoinRoom);
        btn_Exit.onClick.AddListener(ExitGame);
        AudioJam.SoundManager.instance.Play("Tema3");   
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        Debug.Log("Sala ya existe o error");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        Debug.Log("Sala ya existe o error");
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        if (PhotonNetwork.JoinRoom(joinInput.text))
        {
            AudioJam.SoundManager.instance.Stop("Tema3");
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(loadLevelString);
    }

    public void ExitGame()
    {
        AudioJam.SoundManager.instance.Stop("Tema3");
        Application.Quit();
    }
}
