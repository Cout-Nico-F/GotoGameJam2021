using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private PhotonView playerPhotonView;
    [SerializeField] private GameObject desactivateCanvas;

    private void Awake()
    {
        if (!playerPhotonView.IsMine)
        {
            desactivateCanvas.SetActive(false);
        }
        
    }
    private void Update()
    {
        scoreText.text = RoomController.Instance.GoalActual.ToString();
    }

}

