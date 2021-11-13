using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBase : MonoBehaviour
{
    public List<Goal> Goals { get; set; }
    public string QuestName { get; set; }
    public string Description { get; set; }
    public int ExperienceReward { get; set; }
    public bool Completed { get; set; }

    private void Start()
    {
        Goals = new List<Goal>();
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
