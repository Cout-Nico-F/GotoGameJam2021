using System.Collections;
using TMPro;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(TextMeshProUGUI))]
public class TextFramePlayer : MonoBehaviour, IPunObservable
{
    [Header("Enter parameters")]
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private PhotonView photonView;
    [Header("Text settings")]
    [SerializeField] private Color textColor;
    private void Start()
    {
        textMesh.color = textColor;
        AddObservable();
    }
    private void AddObservable()
    {
        if (!photonView.ObservedComponents.Contains(this))
        {
            photonView.ObservedComponents.Add(this);
        }
    }
    public IEnumerator PlayerTalk(string textInput)
    {
        textMesh.text = textInput;
        yield return new WaitForSeconds(3);
        textMesh.text = "";
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(textMesh.text);
        }
        else
        {
            textMesh.text = (string)stream.ReceiveNext();
            Debug.Log("Actualizo: "+textMesh.text);
        }
    }
}
