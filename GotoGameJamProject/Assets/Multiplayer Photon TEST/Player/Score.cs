using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] int playerScore;
    public int PlayerScore { get => playerScore; set => playerScore = value; }
}
