using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPlayer : MonoBehaviour
{
    public Quest activeQuest;


    public void AssignQuest(Quest quest)
    {
        activeQuest = quest;
    }
}
