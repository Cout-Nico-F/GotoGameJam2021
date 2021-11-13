using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGoal : Goal
{
    public int ItemID { get; set; }

    public CollectGoal(int itemID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        ItemID = itemID;
        Description = description;
        Completed = completed;
        CurrentAmount = currentAmount;
        RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        // aqui ira el listener que escuchara el evento de item recogido
        // Player.OnItemPickedUp += ItemPickedUp;
    }


    // este metodo se llamara cuando un item sea recogido
    private void ItemPickedUp(int itemID)
    {
        if (itemID == ItemID)
        {
            CurrentAmount++;
            Evaluate();
        }
    }
}
