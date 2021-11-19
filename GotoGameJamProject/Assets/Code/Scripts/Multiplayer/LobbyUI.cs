
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class LobbyUI : MonoBehaviourPunCallbacks
{
    [SerializeField] private Button btn_Create;
    [SerializeField] private Button btn_Join;
    [SerializeField] private Button btn_ComunitarySV;
    [SerializeField] private string loadLevelString;

    [SerializeField] private InputField createInput;
    [SerializeField] private InputField joinInput;

    private void Awake()
    {
        btn_Create.onClick.AddListener(CreateRoom);
        btn_Join.onClick.AddListener(JoinRoom);
        btn_ComunitarySV.onClick.AddListener(JoinComunitarySV);
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(loadLevelString);
    }

    public void JoinComunitarySV()
    {
        PhotonNetwork.JoinRoom("+1+");
    }
}
