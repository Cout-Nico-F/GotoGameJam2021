using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class InputTextChat : MonoBehaviour
{
    [SerializeField] private ChatSystsem chat;
    [SerializeField] private TMP_InputField tMP_InputField;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(tMP_InputField.text=="")
            {
                tMP_InputField.Select();//Re-focus on the input field
                tMP_InputField.ActivateInputField(); //Re-focus on the input field
            }
            else
            {
                chat.PlayerTalk(tMP_InputField.text);
                EventSystem.current.SetSelectedGameObject(null);
                tMP_InputField.text = "";
            }
        }
    }
}
