using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPlayer : MonoBehaviour
{
    public Quest activeQuest;


    public void AssignQuest(Quest quest)
    {
        activeQuest = quest;
        Debug.Log("Quest " + quest.QuestName + "assigned");
        Debug.Log("Assigned: " + quest.Asigned);
        Debug.Log("Completed: " + quest.Completed);
        Debug.Log("GOALS");

        foreach (var goal in quest.Goals)
        {
            Debug.Log(goal.Description);
            Debug.Log(goal.RequiredAmount);
        }
    }
}
