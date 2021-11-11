using System.Collections;
using TMPro;
using UnityEngine;
using Photon.Pun;

public class TextFramePlayer : MonoBehaviour
{
    [Header("Enter parameters")]
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private PhotonView photonView;
    [Header("Text settings")]
    [SerializeField] private Color textColor;
    private void Start()
    {
        textMesh.color = textColor;
    }


    public IEnumerator PlayerTalk(string textInput)
    {
            textMesh.text = "";
            textMesh.text = textInput;
            photonView.RPC("SyncText", RpcTarget.All, textInput);
            yield return new WaitForSeconds(3);
            photonView.RPC("SyncText", RpcTarget.All, "");
            gameObject.SetActive(false);
    }

    [PunRPC]
    void SyncText(string textInput)
    {
            textMesh.text = "";
            textMesh.text = textInput;
    }
}
