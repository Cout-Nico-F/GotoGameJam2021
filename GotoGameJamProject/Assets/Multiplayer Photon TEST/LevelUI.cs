using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button addScoreButton;
    [SerializeField] private Score score;

    public Score Score { get => score; set => score = value; }

    private void Awake()
    {
        score.PlayerScore = 0;
        addScoreButton.onClick.AddListener(AddScore);
    }

    private void Start()
    {
        scoreText.text = score.PlayerScore + "/" ;
    }

    public void AddScore()
    {
        score.PlayerScore++;
        scoreText.text = score.PlayerScore + "/";
    }

    public void ResetScore()
    {
        score.PlayerScore = 0;
        scoreText.text = score.PlayerScore + "/" ;
    }
}

