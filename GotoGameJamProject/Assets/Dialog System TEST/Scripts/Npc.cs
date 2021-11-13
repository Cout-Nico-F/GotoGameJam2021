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

    public void Interact()
    {
        if (questGiver != null)
        {
            if (questGiver.QuestsAvailable())
            {
                questGiver.ShowQuest();
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
