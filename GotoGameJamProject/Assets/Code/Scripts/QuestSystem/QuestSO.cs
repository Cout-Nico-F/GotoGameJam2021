using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quests/New Quest")]
public class QuestSO : ScriptableObject
{
    public string QuestName;
    public string Description;
    public int ExperienceReward;
    public GameObject MainDialogue;
    public GameObject RememberDialogue;
    public GameObject RewardDialogue;
    public List<GoalSO> Goals;
    public bool InfiniteQuest;
}
