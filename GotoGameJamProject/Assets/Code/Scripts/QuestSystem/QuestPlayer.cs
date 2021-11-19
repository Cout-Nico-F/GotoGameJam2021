using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventoryJam;
using System;

public class QuestPlayer : MonoBehaviour
{
    public Quest activeQuest;
    public bool HasActiveQuest;

    [SerializeField] private Inventory inventory;
    [SerializeField] private LevelUI levelUI;

    private QuestUI questUI;
    

    private void Start()
    {
        questUI = FindObjectOfType<QuestUI>(true);
        HasActiveQuest = false;
        inventory.OnPickedItem += HandlePickedItem;
    }
    

    public void AssignQuest(Quest quest)
    {
        activeQuest = quest;
        HasActiveQuest = true;
        questUI.Show(quest);
    }


    public void RemoveCompletedQuest()
    {
        questUI.Hide(activeQuest);
        activeQuest = null;
        HasActiveQuest = false;
    }


    private void HandlePickedItem(string itemID)
    {
        if (HasActiveQuest)
        {
            foreach (var goal in activeQuest.Goals)
            {
                goal.Evaluate(itemID);
            }

            activeQuest.CheckGoals();
            questUI.UpdateQuest(activeQuest);
        }
    }

    public void GiveReward()
    {
        foreach (var goal in activeQuest.Goals)
        {
            inventory.RemoveItems(goal.ItemID, 1);
        }

        levelUI.AddReward(activeQuest.ExperienceReward);
    }
}
