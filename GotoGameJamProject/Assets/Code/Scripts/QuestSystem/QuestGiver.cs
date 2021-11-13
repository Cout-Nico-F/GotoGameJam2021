using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public GameObject QuestDialogue { get => questDialogue; }

    [SerializeField] private QuestSO[] questSOs;
    [SerializeField] private GameObject questDialogue;
    [SerializeField] private RectTransform dialogueCanvas;

    private List<Quest> quests;


    private void Awake()
    {
        quests = new List<Quest>();

        foreach (var questSO in questSOs)
        {
            List<Goal> goals = new List<Goal>();

            foreach (var goalSO in questSO.Goals)
            {
                Goal goal = new Goal(goalSO.ItemID, goalSO.Description, goalSO.RequiredAmount);
                goals.Add(goal);
            }

            Quest quest = new Quest(goals, questSO.QuestName, questSO.Description, questSO.ExperienceReward);
            quests.Add(quest);
        }    
    }

    public void GiveQuest(Quest quest, QuestPlayer questPlayer)
    {
        DialogueInteract(questDialogue);
        
        quest.Asigned = true;
        questPlayer.AssignQuest(quest);
    }

    private void DialogueInteract(GameObject go)
    {
        var ui = Instantiate(go, dialogueCanvas.transform);
        ui.SetActive(true);        
    }

    public Quest GetNextQuestAvailable()
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
