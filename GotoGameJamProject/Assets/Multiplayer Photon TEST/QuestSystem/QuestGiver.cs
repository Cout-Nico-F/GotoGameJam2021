using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private Quest[] quests;
    public void GiveQuest()
    {
        foreach (var quest in quests)
        {
            if (quest.QuestConfig.Finished == false)
            {
                DialogueInteract(quest.QuestDialogue);
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
            if (quest.QuestConfig.Finished == false)
            {
                return true;
            }
        }
        return false;
    }
}
