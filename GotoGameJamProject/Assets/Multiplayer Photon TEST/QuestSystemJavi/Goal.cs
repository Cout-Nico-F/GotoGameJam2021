using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Goal", menuName = "Goals/New Goal")]
public class Goal : ScriptableObject
{
    public int ItemID;
    public string Description;
    public bool Completed;
    public int CurrentAmount;
    public int RequiredAmount;


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
