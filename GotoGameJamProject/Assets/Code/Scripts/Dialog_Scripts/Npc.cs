using DialogueJam;
using UnityEngine;

public class Npc : MonoBehaviour, Interactable
{
    [SerializeField] private GameObject dialogueIdle;

    private QuestGiver questGiver;


    private void Awake()
    {
        questGiver = GetComponent<QuestGiver>();
    }

    public void Interact(GameObject gameObject)
    {
        var quest = questGiver.GetNextQuestAvailable();

        if (quest != null) // si el Npc ha devuelto una Quest se la asignamos al Player
        {
            if (gameObject.CompareTag("Player"))
            {
                questGiver.GiveQuest(quest, gameObject.GetComponent<QuestPlayer>());
            }
        }
    }

    private void DialogueInteract(GameObject go)
    {
        if (go.activeSelf == false)
        {
            go.SetActive(true);
        }
        else
        {
            go.GetComponentInChildren<DialogueSystem>().NextText = true;
        }
    }
}
