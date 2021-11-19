using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public int Index { get => index; set => index = value; }
    public string QuestName { get => questName; set => questName = value; }
    public string Description { get => description; set => description = value; }
    public int ExperienceReward { get => experienceReward; set => experienceReward = value; }
    public GameObject MainDialogue { get => mainDialogue; set => mainDialogue = value; }
    public GameObject RememberDialogue { get => rememberDialogue; set => rememberDialogue = value; }
    public GameObject RewardDialogue { get => rewardDialogue; set => rewardDialogue = value; }
    public List<Goal> Goals { get => goals; set => goals = value; }
    public bool InfiniteQuest { get => infiniteQuest; set => infiniteQuest = value; }
    public bool Asigned { get => asigned; set => asigned = value; }
    public bool Completed { get => completed; set => completed = value; }
    

    [SerializeField] private string questName;
    [SerializeField] private string description;
    [SerializeField] private int experienceReward;
    [SerializeField] private GameObject mainDialogue;
    [SerializeField] private GameObject rememberDialogue;
    [SerializeField] private GameObject rewardDialogue;
    [SerializeField] private List<Goal> goals;
    [SerializeField] private bool infiniteQuest;
    [SerializeField] private bool asigned;
    [SerializeField] private bool completed;

    private int index;


    public Quest(int index, List<Goal> goals, string questName, string description, int experienceReward, bool infiniteQuest,
                 GameObject mainDialogue, GameObject rememberDialogue, GameObject rewardDialogue)
    {
        Index = index;
        Goals = goals;
        QuestName = questName;
        Description = description;
        ExperienceReward = experienceReward;
        InfiniteQuest = infiniteQuest;
        MainDialogue = mainDialogue;
        RememberDialogue = rememberDialogue;
        RewardDialogue = rewardDialogue;
        Asigned = false;
        Completed = false;
    }
    

    public void CheckGoals()
    {
        foreach (Goal goal in Goals)
        {
            if (!goal.Completed)
            {
                Completed = false;
                return;
            }

        }

        Completed = true;
        Debug.Log("Quest completada");
    }
    
}
