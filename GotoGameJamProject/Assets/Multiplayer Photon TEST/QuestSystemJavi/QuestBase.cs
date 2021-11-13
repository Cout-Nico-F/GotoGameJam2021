using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "New Quest")]
public class QuestBase : ScriptableObject
{
    public List<Goal> Goals;
    public string QuestName;
    public string Description;
    public int ExperienceReward;
    public bool Completed;
    public bool IsActive;

    
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
    
}
