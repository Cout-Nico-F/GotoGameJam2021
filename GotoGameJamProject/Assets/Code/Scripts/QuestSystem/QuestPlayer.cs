using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventoryJam;
using System;

public class QuestPlayer : MonoBehaviour
{
    public bool HasAnyQuestAsigned { get => hasAnyQuestAsigned; set => hasAnyQuestAsigned = value; }

    [SerializeField] private Inventory inventory;
    [SerializeField] private LevelUI levelUI;

    private QuestUI questUI;
    private List<Quest> quests;
    private bool hasAnyQuestAsigned;


    private void Start()
    {
        quests = new List<Quest>();
        questUI = FindObjectOfType<QuestUI>(true);
        hasAnyQuestAsigned = false;
        inventory.OnPickedItem += HandlePickedItem;
    }
    

    public void AssignQuest(Quest quest)
    {
        quests.Add(quest);
        hasAnyQuestAsigned = true;

        // cargamos la quest en la UI como una GoalEntry
        // nos devuelve la posicion en la lista de quest
        // para despues poder eliminarla directamente
        quest.Goal.GoalID = questUI.AddGoal(quest);
    }


    public void RemoveCompletedQuest(Quest quest)
    {
        var position = quest.Goal.GoalID;
        questUI.RemoveGoal(position);
        quests.Remove(quest);

        // ademas de eliminar la quest de la lista hay que reordenar el GoalID del resto
        for (int i = position; i < quests.Count; i++)
        {
            quests[i].Goal.GoalID -= 1;
        }

        if (quests.Count == 0)
            hasAnyQuestAsigned = false;
    }


    private void HandlePickedItem(string itemID)
    {
        if (hasAnyQuestAsigned)
        {
            foreach (var quest in quests)
            {
                quest.Goal.Evaluate(itemID);

                // actualizamos la UI
                if (quest.Goal.CheckItem(itemID))
                    questUI.UpdateGoal(quest);

                if (quest.Goal.Completed)
                    quest.Completed = true;
            }
        }
    }

    public void GiveReward(Quest quest)
    {
        // quitamos los items del inventario
        inventory.RemoveItems(quest.Goal.ItemID, quest.Goal.RequiredAmount);

        // sumamos la recompensa a la UI
        levelUI.AddReward(quest.ExperienceReward);

        // reseteamos la quest si se trata de una infinite quest
        if (quest.InfiniteQuest)
        {
            quest.Completed = false;
            quest.Goal.Completed = false;
            quest.Goal.CurrentAmount = 0;
        }
    }


    public Quest CheckQuestInList(string id)
    {
        foreach (var quest in quests)
        {
            if (quest.QuestID.Equals(id))
            {
                return quest;
            }
        }

        return null;
    }

}
