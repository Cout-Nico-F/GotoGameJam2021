using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Score score;
    [SerializeField] private PhotonView playerPhotonView;
    [SerializeField] private GameObject desactivateCanvas;
    public Score Score { get => score; set => score = value; }

    private void Awake()
    {
        if (!playerPhotonView.IsMine)
        {
            desactivateCanvas.SetActive(false);
        }
        
    }

    private void Start()
    {
        scoreText.text = score.PlayerScore + "/";
    }
    private void Update()
    {
        scoreText.text = RoomController.Instance.GoalActual.ToString();
    }

    public void ResetScore()
    {
        score.PlayerScore = 0;
        scoreText.text = score.PlayerScore + "/";
    }

    public void AddReward(int amount)
    {
        score.PlayerScore += amount;
        scoreText.text = score.PlayerScore + "/";
    }
}

