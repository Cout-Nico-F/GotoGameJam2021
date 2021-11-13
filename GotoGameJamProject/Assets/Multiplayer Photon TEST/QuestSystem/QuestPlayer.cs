using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPlayer : MonoBehaviour
{
    private Quest[] questList = default;

    public Quest[] QuestList { get => questList; }

    public void AddQuest(Quest quest)
    {
        foreach (var item in questList)
        {
            if (quest.Id == item.Id)
            {
                return;
            }
        }
        questList[questList.Length] = quest;
    }
}
