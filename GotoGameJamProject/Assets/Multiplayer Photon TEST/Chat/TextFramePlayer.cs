using System.Collections;
using TMPro;
using UnityEngine;
using Photon.Pun;

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
    }


    public IEnumerator PlayerTalk(string textInput)
    {

        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsReading)
        {

        }
        else
        {

        }
    }
}
