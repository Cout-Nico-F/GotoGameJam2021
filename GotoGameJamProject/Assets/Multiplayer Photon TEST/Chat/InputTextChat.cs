using TMPro;
using UnityEngine;

public class InputTextChat : MonoBehaviour
{
    [SerializeField] private ChatSystem chat;

    public void ReadInputPlayer(string input)
    {
        chat.PlayerTalk(input);
    }
}

