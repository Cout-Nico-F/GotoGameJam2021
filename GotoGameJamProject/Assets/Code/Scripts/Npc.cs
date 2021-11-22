using DialogueJam;
using UnityEngine;

public class Npc : MonoBehaviour, Interactable
{
    public bool GiveReward { get => giveReward; set => giveReward = value; }

    [SerializeField] private GameObject questItemPrefab;
    [SerializeField] private Vector2 positionQuestItem;
    [SerializeField] private Transform parentQuestItem;

    private QuestGiver questGiver;
    private QuestPlayer questPlayer;
    private Quest currentQuest;
    private bool giveReward;
    private float timeBetweenDialogues;


    private void Awake()
    {
        if (GetComponent<QuestGiver>() != null)
        {
            questGiver = GetComponent<QuestGiver>();
        }
    }

    private void Start()
    {
        giveReward = false;
        timeBetweenDialogues = 0f;
        questGiver.OnDialogueEnds += HandleDialogueEnds;
    }


    private void Update()
    {
        if (timeBetweenDialogues > 0)
            timeBetweenDialogues -= Time.deltaTime;
    }


    public void Interact(GameObject interactor)
    {
        // si ya estamos hablando no hacemos nada
        if (questGiver.IsTalking)
            return;

        // si no ha pasado el tiempo para volver a hablar
        if (timeBetweenDialogues > 0)
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

        // si el Npc solo da pistas mostramos directamente el dialogo Idle
        if (!questGiver.HasQuest)
        {
            questGiver.ShowDialogueIdle();
            return;
        }

        // comprobamos si la quest que tiene el Npc la tiene asignada el Player
        currentQuest = CheckQuestInPlayerAssignedQuests();

        // si el Npc tiene una mision que dar pero el Player ya tiene asignada otra misión
        // mostramos el dialogo Busy
        if (questPlayer.HasAnyQuestAsigned && currentQuest == null)
        {
            questGiver.ShowBusyDialogue();
            return;
        }

        // si el Npc ya ha entregado el Reward y no es una quest infinita mostramos el dialogue Idle
        if (questGiver.Quest.RewardGived && !questGiver.Quest.InfiniteQuest)
        {
            questGiver.ShowDialogueIdle();
            return;
        }        

        if (currentQuest != null)
        {
            // si el Player tiene ya asignada la Quest comprobamos si la ha completado
            if (currentQuest.Completed)
            {
                // mostramos el dialogo questReward
                questGiver.GiveReward();

                // activamos el bool para que cuando acabe el dialogo le de la recompensa
                giveReward = true;
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

            // instanciamos el item requerido en la Quest
            Instantiate(questItemPrefab, positionQuestItem, Quaternion.identity, parentQuestItem);
        }
    }


    private Quest CheckQuestInPlayerAssignedQuests()
    {
        return questPlayer.CheckQuestInList(questGiver.Quest.QuestID);
    }


    private void HandleDialogueEnds(bool dialogueEnds)
    {
        timeBetweenDialogues = 2f;
        if (giveReward)
        {
            // le damos la recompensa
            if (!currentQuest.InfiniteQuest)
                currentQuest.RewardGived = true;

            questPlayer.GiveReward(currentQuest);

            // eliminamos la quest completada de la UI y del PLayer
            questPlayer.RemoveCompletedQuest(currentQuest);

            giveReward = false;
        }
    }
}
