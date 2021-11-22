
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
        AudioJam.SoundManager.instance.Play("Tema1");
    }

    public void CreateRoom()
    {
        AudioJam.SoundManager.instance.Stop("Tema1");

        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        AudioJam.SoundManager.instance.Stop("Tema1");

        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(loadLevelString);
    }
    public void ExitGame()
    {
        AudioJam.SoundManager.instance.Stop("Tema1");
        Application.Quit();
    }
}
