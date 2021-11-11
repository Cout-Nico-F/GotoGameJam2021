using DialogueJam;
using UnityEngine;

public class Npc : MonoBehaviour, Interactable
{
    [SerializeField] private GameObject dialogueIdle;

    [SerializeField] private bool hasQuests;
    private QuestGiver questGiver;

    private void Start()
    {
        questGiver = GetComponent<QuestGiver>();
    }

    public void Interact()
    {
        if (questGiver != null)
        {
            if (questGiver.QuestsAvailable())
            {
                questGiver.GiveQuest();
            }  
        }
        else
        {
            DialogueInteract(dialogueIdle);
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
