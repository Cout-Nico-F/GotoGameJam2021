using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private QuestBase[] quests;
    [SerializeField] private GameObject questDialogue;
    [SerializeField] private RectTransform dialogueCanvas;
    public GameObject QuestDialogue { get => questDialogue; }
    

    public void GiveQuest(QuestBase quest, QuestPlayer questPlayer)
    {
        DialogueInteract(questDialogue);
        
        quest.Asigned = true;
        questPlayer.AddQuest(quest);
    }

    private void DialogueInteract(GameObject go)
    {
        var ui = Instantiate(go, dialogueCanvas.transform);
        ui.SetActive(true);        
    }

    public QuestBase GetNextQuestAvailable()
    {
        foreach (var quest in quests)
        {
            if (!quest.Completed && !quest.Asigned)
            {
                return quest;
            }
        }
        return null;
    }

}
