using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using Photon.Pun;

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
                var photonViews = UnityEngine.Object.FindObjectsOfType<PhotonView>();
                foreach (var view in photonViews)
                {
                    var player = view.Owner;
                    //Objects in the scene don't have an owner, its means view.owner will be null
                    if (player != null)
                    {
                        var playerPrefabObject = view.gameObject;
                        if(playerPrefabObject.GetComponent<PlayerMovementTOPDOWN>()!=null)
                        {
                            playerPrefabObject.GetComponent<PlayerMovementTOPDOWN>().IsChating = true ;
                        }
                    }
                }
            }
            else
            {
                var photonViews = UnityEngine.Object.FindObjectsOfType<PhotonView>();
                foreach (var view in photonViews)
                {
                    var player = view.Owner;
                    //Objects in the scene don't have an owner, its means view.owner will be null
                    if (player != null)
                    {
                        var playerPrefabObject = view.gameObject;
                        if (playerPrefabObject.GetComponent<PlayerMovementTOPDOWN>() != null)
                        {
                            playerPrefabObject.GetComponent<PlayerMovementTOPDOWN>().IsChating = false;
                        }
                    }
                }
                chat.PlayerTalk(tMP_InputField.text);
                EventSystem.current.SetSelectedGameObject(null);
                tMP_InputField.text = "";
            }
        }
    }
}
