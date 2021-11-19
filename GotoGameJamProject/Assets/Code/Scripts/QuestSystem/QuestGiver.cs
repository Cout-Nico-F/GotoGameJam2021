using System.Collections.Generic;
using UnityEngine;
using DialogueJam;

public class QuestGiver : MonoBehaviour
{
    public bool IsTalking { get => isTalking; set => isTalking = value; }

    [SerializeField] private GameObject idleDialogue;
    [SerializeField] private QuestSO[] questSOs;
    [SerializeField] private RectTransform dialogueCanvas;
    [SerializeField] private List<Quest> questsInspector;

    private GameObject mainDialogue;
    private GameObject rememberDialogue;
    private GameObject rewardDialogue;
    private PlayerMovementTOPDOWN playerMovement;
    private DialogueSystem dialogueSystem;
    private List<Quest> quests;
    private bool isTalking;
    private int currentQuestId;

    private void Awake()
    {
        quests = new List<Quest>();

        for (var i = 0; i < questSOs.Length; i++)
        {
            List<Goal> goals = new List<Goal>();
            List<GoalSO> goalSO = questSOs[i].Goals;
            for (var j = 0; j < goalSO.Count; j++)
            {
                Goal goal = new Goal(j, goalSO[j].ItemID, goalSO[j].Description, goalSO[j].RequiredAmount, goalSO[j].infiniteGoal);
                goals.Add(goal);
            }

            Quest quest = new Quest(i, goals, questSOs[i].QuestName, questSOs[i].Description, questSOs[i].ExperienceReward, questSOs[i].InfiniteQuest,
                                    questSOs[i].MainDialogue, questSOs[i].RememberDialogue, questSOs[i].RewardDialogue);
            quests.Add(quest);
        }

        questsInspector = quests;
    }

    public void GiveQuest(int questIndex, QuestPlayer questPlayer)
    {        
        var quest = quests[questIndex];
        mainDialogue = quest.MainDialogue;
        DialogueInteract(mainDialogue);
        quest.Asigned = true;
        questPlayer.AssignQuest(quest);
    }


    public void RememberQuest(int questIndex)
    {
        var quest = quests[questIndex];
        rememberDialogue = quest.RememberDialogue;
        DialogueInteract(rememberDialogue);
    }


    public void ShowDialogueIdle()
    {
        DialogueInteract(idleDialogue);
    }


    public void GiveReward(int questIndex)
    {
        var quest = quests[questIndex];
        rewardDialogue = quest.RewardDialogue;
        DialogueInteract(rewardDialogue);
    }


    private void DialogueInteract(GameObject go)
    {
        playerMovement = FindObjectOfType<PlayerMovementTOPDOWN>();
        if (playerMovement != null)
        {
            playerMovement.IsTalking = true;
        }
     
        var ui = Instantiate(go, dialogueCanvas.transform);
        ui.SetActive(true);
        isTalking = true;

        dialogueSystem = ui.GetComponentInChildren<DialogueSystem>();
        if (dialogueSystem != null)
        {
            dialogueSystem.OnDialogueEnds += HandleDialogueEnds;
        }        
    }

    public void HandleDialogueEnds(bool dialogoEnd)
    {
        if (dialogoEnd)
        {
            playerMovement.IsTalking = false;
            isTalking = false;
            dialogueSystem.OnDialogueEnds -= HandleDialogueEnds;
        }
    }

    public Quest GetNextQuestAvailable()
    {
        foreach (var quest in quests)
        {
            if (!quest.Completed && !quest.Asigned)
            {
                currentQuestId = quest.Index;
                return quest;
            }
        }
        return null;
    }
    
}
