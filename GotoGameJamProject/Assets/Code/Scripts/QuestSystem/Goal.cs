using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public int GoalID { get; set; }
    public string ItemID { get; set; }
    public bool Completed { get; set; }
    public int CurrentAmount { get; set; }
    public int RequiredAmount { get; set; }


    public Goal(GoalSO goal)
    {
        GoalID = -1;
        ItemID = goal.ItemID;
        Completed = false;
        CurrentAmount = 0;
        RequiredAmount = goal.RequiredAmount;
    }

    
    public void Evaluate(string item)
    {
        if (item.Equals(ItemID))
        {
            CurrentAmount++;
            if (CurrentAmount >= RequiredAmount)
            {
                Completed = true;
            }
        }        
    }

    public bool CheckItem(string item)
    {
        return item.Equals(ItemID);
    }


    public void SubtractItem()
    {
        CurrentAmount--;
        if (CurrentAmount < 0)
            CurrentAmount = 0;

        if (CurrentAmount < RequiredAmount)
        {
            Completed = false;
        }
    }
}
