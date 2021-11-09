using UnityEngine;
using TMPro;

public class LevelUI : MonoBehaviour
{
    private int score;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        score = 0;
    }

    private void Start()
    {
        scoreText.text = score + "/" ;
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score + "/";
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = score + "/" ;
    }
}

