using TMPro;
using UnityEngine;

public class ChatSystsem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;

    public void PlayerTalk(string textInput)
    {
        textMesh.text = textMesh.text + "\n" + textInput;
    }
}
