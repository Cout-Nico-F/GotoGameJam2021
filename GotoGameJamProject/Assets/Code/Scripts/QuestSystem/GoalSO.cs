using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Goal", menuName = "Goals/New Goal")]
public class GoalSO : ScriptableObject
{
    public string ItemID;
    public string Description;
    public int RequiredAmount;
    public bool infiniteGoal;
}
