using System.Collections;
using System.Collections.Generic;
using DialogueJam;
using UnityEngine;

public class Npc : MonoBehaviour, Interactable
{
    [SerializeField] private GameObject dialogueIdle;
    [SerializeField] private GameObject dialogueQuest1;
    [SerializeField] private GameObject dialogueQuest2;
    private Quest quest1;
    private Quest quest2;

    public void Interact()
    {
        if (quest1.State.Finished == false) //
        {
            DialogueInteract(dialogueQuest1);
            return;
        }
        else if (quest2.State.Finished == false)
        {
            DialogueInteract(dialogueQuest2);
            return;
        }
        else
        {
            DialogueInteract(dialogueIdle);
        }
    }

    private void DialogueInteract(GameObject go)
    {
        if (go.activeSelf == false)
        {
            go.SetActive(true);
        }
        else
        {
            go.GetComponentInChildren<DialogueSystem>().NextText = true;
        }
    }
}
