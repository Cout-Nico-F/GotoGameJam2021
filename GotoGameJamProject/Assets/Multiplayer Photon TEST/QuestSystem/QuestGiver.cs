using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private Quest[] quests;
    private QuestPlayer questPlayer;
    public void ShowQuest()
    {
        foreach (var quest in quests)
        {
            if (quest.IsFinished == false)
            {
                //Give quest me suena que va aca pero capas tambien necesitamos que haya Aceptado la mision con alguna interaccion con la ui
                GiveQuest(quest);
                return;
            }
        }
    }

    private void GiveQuest(Quest quest)
    {
        DialogueInteract(quest.QuestDialogue);
        //aca deberia dar la quest.
        //1) player.activeQuest = quest o Player.ActiveQuests.add(quest)
        questPlayer = FindMyPlayerQuests();
        questPlayer.QuestList.Add(quest);//TODO: prevenir que se agregue mas de una vez la misma mision?
        quest.IsActive = true;
        //y 2) mostrar quest y progreso en UI ( la ui podria hacer esto sola ya que quest es un scriptable obj )

        //tambien podriamos tener o no un booleano que nos diga si ya aceptamos esa mision antes para no volver a preguntar si acepta mision.
        //pero haciendo algun refactor porque actualmente no se donde lo pondria
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
            if (quest.IsFinished == false)
            {
                return true;
            }
        }
        return false;
    }

    public QuestPlayer FindMyPlayerQuests()
    {
        var a = FindObjectsOfType<QuestPlayer>();

        foreach (var q in a)
        {
            if (q.GetComponent<Photon.Pun.PhotonView>().IsMine)
            {
                return q;
            }
        }
        return null;
    }
}
