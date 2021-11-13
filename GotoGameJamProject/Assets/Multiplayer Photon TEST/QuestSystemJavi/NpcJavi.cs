using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcJavi : MonoBehaviour, IInteractable
{
    [SerializeField] private QuestGiverJavi questGiver;


    public void Interact(GameObject gameObject)
    {
        var quest = questGiver.GetNextQuestAvailable();

        if (quest != null) // si el Npc ha devuelto una Quest se la asignamos al Player
        {
            if (gameObject.CompareTag("Player"))
            {
                questGiver.GiveQuest(quest, gameObject.GetComponent<QuestPlayerJavi>());
            }
        }
    }
}
