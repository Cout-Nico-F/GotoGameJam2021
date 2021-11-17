using DialogueJam;
using UnityEngine;

public class Npc : MonoBehaviour, Interactable
{
    private QuestGiver questGiver;
    private QuestPlayer questPlayer;


    private void Awake()
    {
        questGiver = GetComponent<QuestGiver>();
    }

    public void Interact(GameObject gameObject)
    {
        // lo normal es que el Player sea el unico que interactua con un Npc
        // pero por si acaso
        if (!gameObject.CompareTag("Player"))
        {
            Debug.LogError("El gameobject que interactua no es un Player");
            return;
        }

        // recuperamos el QuestPlayer
        questPlayer = gameObject.GetComponent<QuestPlayer>();
        if (questPlayer == null)
        {
            Debug.LogError("No existe el componente QuestPlayer en el Player");
            return;
        }

        var HasPlayerActiveQuest = CheckPlayerActiveQuest();

        if (HasPlayerActiveQuest)
        {
            // si tiene una Quest activa comprobamos si la ha completado
            // y si es asi le damos la recompensa
            if (questPlayer.activeQuest.Asigned && questPlayer.activeQuest.Completed)
            {
                // le damos la recompensa
                questPlayer.GiveReward();

                // despues intentamos asignarle otra mision
                AssignNextQuest();
            }
            else
            {
                // si tiene la Quest Asignada se la recordamos
                if (questPlayer.activeQuest.Asigned)
                {
                    questGiver.RememberQuest();
                }
            }
        }
        else
        {
            AssignNextQuest();
        }
    }


    private bool CheckPlayerActiveQuest()
    {
        return questPlayer.HasActiveQuest;
    }


    private void AssignNextQuest()
    {
        var quest = questGiver.GetNextQuestAvailable();

        if (quest != null) // si el Npc ha devuelto una Quest se la asignamos al Player
        {
            questGiver.GiveQuest(quest.Index, questPlayer);
        }
        else
        {
            // si no hay ninguna Quest lanzamos el dialogo Idle
            questGiver.ShowDialogueIdle();
        }
    }
    
}
