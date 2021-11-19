using System.Collections.Generic;
using UnityEngine;
using DialogueJam;

public class QuestGiver : MonoBehaviour
{
    public bool IsTalking { get => isTalking; set => isTalking = value; }
    public Quest Quest { get => quest; set => quest = value; }

    [SerializeField] private GameObject idleDialogue;
    [SerializeField] private QuestSO questSO;
    [SerializeField] private RectTransform dialogueCanvas;

    private GameObject mainDialogue;
    private GameObject rememberDialogue;
    private GameObject rewardDialogue;
    private PlayerMovementTOPDOWN playerMovement;
    private DialogueSystem dialogueSystem;
    private Quest quest;
    private bool isTalking;

    private void Awake()
    {
        var goal = new Goal(questSO.Goal);
        quest = new Quest(questSO.QuestID, questSO.Description, goal, questSO.ExperienceReward, questSO.MainDialogue,
                          questSO.RememberDialogue, questSO.RewardDialogue, questSO.InfiniteQuest);
        mainDialogue = quest.MainDialogue;
        rememberDialogue = quest.RememberDialogue;
        rewardDialogue = quest.RewardDialogue;
    }

    public void GiveQuest(QuestPlayer questPlayer)
    {        
        DialogueInteract(mainDialogue);
        questPlayer.AssignQuest(quest);
    }


    public void RememberQuest()
    {
        DialogueInteract(rememberDialogue);
    }


    public void ShowDialogueIdle()
    {
        DialogueInteract(idleDialogue);
    }


    public void GiveReward()
    {
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
    
}
