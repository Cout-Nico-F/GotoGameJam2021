using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPlayer : MonoBehaviour
{
    private List<Quest> questList = default;

    public List<Quest> QuestList { get => questList; }

    public void AddQuest(Quest quest)
    {
        foreach (var item in questList)
        {
            if (quest.Id == item.Id)
            {
                return;
            }
        }
        questList.Add(quest);
    }
}
