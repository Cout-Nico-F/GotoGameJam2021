using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUI : MonoBehaviour
{    
    [SerializeField] private RectTransform container;
    [SerializeField] private TextMeshProUGUI largeDescriptionText;
    [SerializeField] private Button leaveQuestButton;
    [SerializeField] private GoalEntryView goalEntryViewPrefab;

    private QuestPlayer questPlayer;
    private List<GoalEntryView> _goalEntryViews;


    private void Awake()
    {
        leaveQuestButton.onClick.AddListener(LeaveQuest);
        _goalEntryViews = new List<GoalEntryView>();
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
        largeDescriptionText.text = string.Empty;
        var entry = _goalEntryViews[position];
        Destroy(entry.gameObject);
        _goalEntryViews.RemoveAt(position);        
    }

    
    public void UpdateGoal(Quest quest)
    {
        var entry = _goalEntryViews[quest.Goal.GoalID];
        entry.Configure(quest.Goal.Completed, quest.Description, quest.Goal.CurrentAmount, quest.Goal.RequiredAmount);
    }


    public void AddLargeDescription(string description)
    {
        largeDescriptionText.text = description;
    }


    private void LeaveQuest()
    {
        if (questPlayer == null)
            questPlayer = FindObjectOfType<QuestPlayer>();

        if (questPlayer == null)
        {
            Debug.LogError("No encuentro al Player");
        }
        else
        {
            if (questPlayer.HasAnyQuestAsigned)
                questPlayer.RemoveLeavedQuest();
        }
    }
}
