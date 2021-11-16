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

    public void Show(Quest quest)
    {
        gameObject.SetActive(true);
        
        foreach (var goal in quest.Goals)
        {
            var goalEntry = Instantiate(goalEntryViewPrefab, container);
            _goalEntryViews.Add(goalEntry);
            goalEntry.Configure(goal.Completed, goal.Description, goal.CurrentAmount, goal.RequiredAmount);
        }
    }


    public void Hide()
    {
        gameObject.SetActive(false);
        CleanGoals();
    }


    public void CleanGoals()
    {
        foreach (var entry in _goalEntryViews)
        {
            Destroy(entry.gameObject);
        }

        _goalEntryViews.Clear();
    }


    public void UpdateQuest(Quest quest)
    {
        CleanGoals();
        Show(quest);
    }
}
