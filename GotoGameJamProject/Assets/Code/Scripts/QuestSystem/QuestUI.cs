using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour
{    
    [SerializeField] private RectTransform container;
    [SerializeField] private GoalEntryView goalEntryViewPrefab;

    private QuestPlayer questPlayer;
    private List<GoalEntryView> _goalEntryViews;


    private void Awake()
    {
        _goalEntryViews = new List<GoalEntryView>();
        questPlayer = GetComponent<QuestPlayer>();
    }

    public int AddGoal(Quest quest)
    {
        var goalEntry = Instantiate(goalEntryViewPrefab, container);
        goalEntry.Configure(quest.Goal.Completed, quest.Description, quest.Goal.CurrentAmount, quest.Goal.RequiredAmount);
        _goalEntryViews.Add(goalEntry);
        return _goalEntryViews.Count-1;
    }


    public void RemoveGoal(int position)
    {
        var entry = _goalEntryViews[position];
        Destroy(entry.gameObject);
        _goalEntryViews.RemoveAt(position);        
    }

    
    public void UpdateGoal(Quest quest)
    {
        var entry = _goalEntryViews[quest.Goal.GoalID];
        entry.Configure(quest.Goal.Completed, quest.Description, quest.Goal.CurrentAmount, quest.Goal.RequiredAmount);
    }
}
