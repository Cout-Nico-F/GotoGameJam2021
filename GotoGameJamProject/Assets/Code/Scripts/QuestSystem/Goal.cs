using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public int Index { get; set; }
    public int ItemID { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public int CurrentAmount { get; set; }
    public int RequiredAmount { get; set; }


    public Goal(int index, int itemID, string description, int requiredAmount)
    {
        Index = index;
        ItemID = itemID;
        Description = description;
        Completed = false;
        CurrentAmount = 0;
        RequiredAmount = requiredAmount;
    }

    
    // comprobamos si se cumple el Goal
    public void Evaluate(int item)
    {
        if (item == ItemID)
        {
            CurrentAmount++;
            if (CurrentAmount >= RequiredAmount)
            {
                Completed = true;
            }
        }        
    }

}
