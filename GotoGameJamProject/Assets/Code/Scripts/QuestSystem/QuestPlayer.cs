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
}
