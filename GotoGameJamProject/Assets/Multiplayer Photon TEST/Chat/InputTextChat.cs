using UnityEngine;

public class InputTextChat : MonoBehaviour
{
    [SerializeField] private ChatSystsem chat;

    public void ReadPlayerText(string input)
    {
        chat.PlayerTalk(input);
    }
}
