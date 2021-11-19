using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quests/New Quest")]
public class QuestSO : ScriptableObject
{
    public string QuestID;
    public string Description;
    public GoalSO Goal;
    public int ExperienceReward;
    public GameObject MainDialogue;
    public GameObject RememberDialogue;
    public GameObject RewardDialogue;
    public bool InfiniteQuest;
}
