using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPlayer : MonoBehaviour
{
    public Quest activeQuest;
    public bool HasActiveQuest;


    private void Start()
    {
        HasActiveQuest = false;
        // aqui ira el listener que escuchara el evento de item recogido
        // Player.OnItemPickedUp += ItemPickedUp;
    }

    public void AssignQuest(Quest quest)
    {
        activeQuest = quest;
        HasActiveQuest = true;
    }


    // este metodo se llamara cuando un item sea recogido
    private void ItemPickedUp(int itemID)
    {
        if (activeQuest != null)
        {
            foreach (var goal in activeQuest.Goals)
            {
                goal.Evaluate(itemID);
            }

            activeQuest.CheckGoals();
        }
    }
}
