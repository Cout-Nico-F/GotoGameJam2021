using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public int Index { get => index; set => index = value; }
    public List<Goal> Goals { get => goals; set => goals = value; }
    public string QuestName { get => questName; set => questName = value; }
    public string Description { get => description; set => description = value; }
    public int ExperienceReward { get => experienceReward; set => experienceReward = value; }
    public bool Asigned { get => asigned; set => asigned = value; }
    public bool Completed { get => completed; set => completed = value; }

    [SerializeField] private int index;
    [SerializeField] private List<Goal> goals;
    [SerializeField] private string questName;
    [SerializeField] private string description;
    [SerializeField] private int experienceReward;
    [SerializeField] private bool asigned;
    [SerializeField] private bool completed;


    public Quest(int index, List<Goal> goals, string questName, string description, int experienceReward)
    {
        Index = index;
        Goals = goals;
        QuestName = questName;
        Description = description;
        ExperienceReward = experienceReward;
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
    }

    public void GiveReward()
    {

    }
}
