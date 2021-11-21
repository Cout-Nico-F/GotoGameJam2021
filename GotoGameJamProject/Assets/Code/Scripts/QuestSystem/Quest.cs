using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string QuestID { get => questID; set => questID = value; }
    public string Description { get => description; set => description = value; }
    public string LargeDescription { get => largeDescription; set => largeDescription = value; }

    public Goal Goal { get => goal; set => goal = value; }
    public int ExperienceReward { get => experienceReward; set => experienceReward = value; }
    public GameObject MainDialogue { get => mainDialogue; set => mainDialogue = value; }
    public GameObject RememberDialogue { get => rememberDialogue; set => rememberDialogue = value; }
    public GameObject RewardDialogue { get => rewardDialogue; set => rewardDialogue = value; }
    public GameObject BusyDialogue { get => busyDialogue; set => busyDialogue = value; }

    public bool InfiniteQuest { get => infiniteQuest; set => infiniteQuest = value; }
    public bool Completed { get => completed; set => completed = value; }
    public bool RewardGived { get => rewardGived; set => rewardGived = value; }

    [SerializeField] private string questID;
    [SerializeField] private string description;
    [SerializeField] private string largeDescription;
    [SerializeField] private Goal goal;
    [SerializeField] private int experienceReward;
    [SerializeField] private GameObject mainDialogue;
    [SerializeField] private GameObject rememberDialogue;
    [SerializeField] private GameObject rewardDialogue;
    [SerializeField] private GameObject busyDialogue;
    [SerializeField] private bool infiniteQuest;
    [SerializeField] private bool completed;
    [SerializeField] private bool rewardGived;



    public Quest(string questID, string description, string largeDescription, Goal goal, int experienceReward, GameObject mainDialogue,
        GameObject rememberDialogue, GameObject rewardDialogue, GameObject busyDialogue, bool infiniteQuest)
    {
        QuestID = questID;
        Description = description;
        LargeDescription = largeDescription;
        Goal = goal;
        ExperienceReward = experienceReward;
        MainDialogue = mainDialogue;
        RememberDialogue = rememberDialogue;
        RewardDialogue = rewardDialogue;
        BusyDialogue = busyDialogue;
        InfiniteQuest = infiniteQuest;
        Completed = false;
        RewardGived = false;
    }
    
}
