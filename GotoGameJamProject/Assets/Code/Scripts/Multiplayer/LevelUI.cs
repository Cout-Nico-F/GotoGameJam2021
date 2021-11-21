using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private PhotonView playerPhotonView;
    [SerializeField] private GameObject desactivateCanvas;

    private void Awake()
    {
        if (!playerPhotonView.IsMine)
        {
            desactivateCanvas.SetActive(false);
        }      
    }
}

