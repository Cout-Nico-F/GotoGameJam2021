using UnityEngine;
using DialogueJam;
using System;
using Photon.Pun;

public class QuestGiver : MonoBehaviour
{
    public bool IsTalking { get => isTalking; set => isTalking = value; }
    public Quest Quest { get => quest; set => quest = value; }
    public bool HasQuest { get => hasQuest; set => hasQuest = value; }

    public event Action<bool> OnDialogueEnds;

    [SerializeField] private GameObject idleDialogue;
    [SerializeField] private QuestSO questSO;
    [SerializeField] private RectTransform dialogueCanvas;
    [SerializeField] private QuestUI questUI;

    [SerializeField] private bool hasQuest;
    private GameObject mainDialogue;
    private GameObject rememberDialogue;
    private GameObject rewardDialogue;
    private GameObject busyDialogue;
    private PlayerMovementTOPDOWN playerMovement;
    private DialogueSystem dialogueSystem;
    private Quest quest;
    private bool isTalking;

    private void Awake()
    {
        if (!hasQuest) return;

        var goal = new Goal(questSO.Goal);
        quest = new Quest(questSO.QuestID, questSO.Description, questSO.LargeDescription, goal, questSO.ExperienceReward, questSO.MainDialogue,
                          questSO.RememberDialogue, questSO.RewardDialogue, questSO.BusyDialogue, questSO.InfiniteQuest);
        mainDialogue = quest.MainDialogue;
        rememberDialogue = quest.RememberDialogue;
        rewardDialogue = quest.RewardDialogue;
        busyDialogue = quest.BusyDialogue;
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


    public void ShowBusyDialogue()
    {
        DialogueInteract(busyDialogue);
    }


    private void DialogueInteract(GameObject go)
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
                    playerPrefabObject.GetComponent<PlayerMovementTOPDOWN>().IsTalking = true;
                }
            }
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

    public void HandleDialogueEnds(bool dialogueEnds)
    {
        if (dialogueEnds)
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
                        playerPrefabObject.GetComponent<PlayerMovementTOPDOWN>().IsTalking = false;
                    }
                }
            }
            isTalking = false;
            questUI.SetLeaveQuestButtonState(true);
            OnDialogueEnds?.Invoke(true);
            dialogueSystem.OnDialogueEnds -= HandleDialogueEnds;
        }
    }
    
}
