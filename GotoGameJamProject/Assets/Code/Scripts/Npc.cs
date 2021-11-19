using DialogueJam;
using UnityEngine;

public class Npc : MonoBehaviour, Interactable
{
    private QuestGiver questGiver;
    private QuestPlayer questPlayer;


    private void Awake()
    {
        if (GetComponent<QuestGiver>() != null)
        {
            questGiver = GetComponent<QuestGiver>();
        }
    }

    public void Interact(GameObject interactor)
    {
        // si ya estamos hablando no hacemos nada
        if (questGiver.IsTalking)
            return;

        // lo normal es que el Player sea el unico que interactua con un Npc
        // pero por si acaso
        if (!interactor.CompareTag("Player"))
        {
            Debug.LogError("El gameobject que interactua no es un Player");
            return;
        }

        // recuperamos el QuestPlayer
        questPlayer = interactor.GetComponent<QuestPlayer>();
        if (questPlayer == null)
        {
            Debug.LogError("No existe el componente QuestPlayer en el Player");
            return;
        }

        // si el Npc tiene la quest completada y no es una quest infinita mostramos el dialogue Idle
        if (questGiver.Quest.Completed && !questGiver.Quest.InfiniteQuest)
        {
            questGiver.ShowDialogueIdle();
            return;
        }


        // comprobamos si la quest que tiene el Npc la tiene asignada el Player
        var quest = CheckQuestInPlayerAssignedQuests();

        if (quest != null)
        {
            // si el Player tiene ya asignada la Quest comprobamos si la ha completado
            if (quest.Completed)
            {
                // mostramos el dialogo questReward
                questGiver.GiveReward();

                // le damos la recompensa
                questPlayer.GiveReward(quest);

                // eliminamos la quest completada de la UI y del PLayer
                questPlayer.RemoveCompletedQuest(quest);
            }
            else
            {
                // si no la ha completado se la recordamos
                questGiver.RememberQuest();
            }
        }
        else
        {
            // si el Player no tiene asignada todavia la quest del Npc se la asignamos
            questGiver.GiveQuest(questPlayer);
        }
    }


    private Quest CheckQuestInPlayerAssignedQuests()
    {
        return questPlayer.CheckQuestInList(questGiver.Quest.QuestID);
    }


}
