using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private Quest[] quests;
    public void ShowQuest()
    {
        foreach (var quest in quests)
        {
            if (quest.QuestConfig.Finished == false)
            {
                DialogueInteract(quest.QuestDialogue);
                //Give quest me suena que va aca pero capas tambien necesitamos que haya Aceptado la mision con alguna interaccion con la ui
                GiveQuest();
                return;
            }
        }
    }

    private void GiveQuest()
    {
        //aca deberia dar la quest.
        //y una clase o metodo aparte hacer los pasos:
        //1) player.activeQuest = quest o Player.ActiveQuests.add(quest)
        //y 2) mostrar quest y progreso en UI
        //tambien podriamos tener o no un booleano que nos diga si ya aceptamos esa mision antes para no volver a preguntar.
    }

    private void DialogueInteract(GameObject go)
    {
        if (go.activeSelf == false)
        {
            go.SetActive(true);
        }
        else
        {
            go.GetComponentInChildren<DialogueJam.DialogueSystem>().NextText = true;
        }
    }

    public bool QuestsAvailable()
    {
        foreach (var quest in quests)
        {
            if (quest.QuestConfig.Finished == false)
            {
                return true;
            }
        }
        return false;
    }
}
