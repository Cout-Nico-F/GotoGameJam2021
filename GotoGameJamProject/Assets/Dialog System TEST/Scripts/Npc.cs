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

    public void Interact(QuestPlayer questPlayer)
    {
        if (questGiver != null)
        {
            if (questGiver.QuestsAvailable())
            {
                questGiver.ShowQuest(questPlayer);
            }
        }
        else
        {
            DialogueInteract(dialogueIdle);
        }
    }
}
