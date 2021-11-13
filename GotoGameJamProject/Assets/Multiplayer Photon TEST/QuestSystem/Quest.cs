using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public List<Goal> Goals { get; set; }
    public string QuestName { get; set; }
    public string Description { get; set; }
    public int ExperienceReward { get; set; }
    public bool Asigned { get; set; }
    public bool Completed { get; set; }


    public Quest(List<Goal> goals, string questName, string description, int experienceReward)
    {
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

    private void GiveReward()
    {

    }
}
