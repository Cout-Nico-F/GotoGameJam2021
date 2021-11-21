using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quests/New Quest")]
public class QuestSO : ScriptableObject
{
    public string QuestID;
    public string Description;
    public string LargeDescription;
    public GoalSO Goal;
    public int ExperienceReward;
    public GameObject MainDialogue;
    public GameObject RememberDialogue;
    public GameObject RewardDialogue;
    public GameObject BusyDialogue;
    public bool InfiniteQuest;
}
