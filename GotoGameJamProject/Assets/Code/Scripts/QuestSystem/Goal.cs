using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public int ItemID { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public int CurrentAmount { get; set; }
    public int RequiredAmount { get; set; }


    public Goal(int itemID, string description, int requiredAmount)
    {
        ItemID = itemID;
        Description = description;
        Completed = false;
        CurrentAmount = 0;
        RequiredAmount = requiredAmount;
    }


    public void Init()
    {
        // aqui ira el listener que escuchara el evento de item recogido
        // Player.OnItemPickedUp += ItemPickedUp;
    }

    // comprobamos si se cumple el Goal
    public void Evaluate()
    {
        if (CurrentAmount >= RequiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        Completed = true;
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
