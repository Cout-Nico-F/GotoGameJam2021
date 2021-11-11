using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private Quest[] quests;
    public void GiveQuest()
    {
        foreach (var quest in quests)
        {
            if (quest.State.Finished == false)
            {
                DialogueInteract(quest.DialogueQuest);
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
