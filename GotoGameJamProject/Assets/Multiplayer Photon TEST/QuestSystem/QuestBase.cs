using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quests/New Quest")]
public class QuestBase : ScriptableObject
{
    public List<Goal> Goals;
    public string QuestName;
    public string Description;
    public int ExperienceReward;
    public bool Asigned;
    public bool Completed;
    

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
