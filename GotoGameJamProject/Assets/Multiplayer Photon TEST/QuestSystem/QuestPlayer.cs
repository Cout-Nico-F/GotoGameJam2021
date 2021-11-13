using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPlayer : MonoBehaviour
{
    [SerializeField] private List<QuestBase> quests;


    public void AddQuest(QuestBase quest)
    {
        quests.Add(quest);
    }
}
