using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quests/New Quest")]
public class QuestSO : ScriptableObject
{
    public List<GoalSO> Goals;
    public string QuestName;
    public string Description;
    public int ExperienceReward;
    public bool InfiniteQuest;
}
