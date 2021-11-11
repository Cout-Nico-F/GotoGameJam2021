using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private Quest[] quests;
    [SerializeField] private GameObject dialogueQuest1;
    [SerializeField] private GameObject dialogueQuest2;
    public void GiveQuest()
    {
        foreach (var quest in quests)
        {
            if (quest.State.Finished == false) //
            {
                DialogueInteract(dialogueQuest1);
                return;
            }
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
            go.GetComponentInChildren<DialogueJam.DialogueSystem>().NextText = true;
        }
    }

    public bool QuestsAvailable()
    {
        foreach (var quest in quests)
        {
            if (quest.State.Finished == false)
            {
                return true;
            }
        }
        return false;
    }
}
