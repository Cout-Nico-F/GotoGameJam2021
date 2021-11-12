using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private Quest[] quests;
    private QuestPlayer questPlayer;
    [SerializeField] private GameObject questDialogue;
    public GameObject QuestDialogue { get => questDialogue; }

    public void ShowQuest()
    {
        foreach (var quest in quests)
        {
            if (quest.IsFinished == false)
            {
                //para simplificar: las misiones no se aceptan.
                GiveQuest(quest);
                return;
            }
        }
    }

    private void GiveQuest(Quest quest)
    {
        //DialogueInteract(questDialogue);
        questPlayer = FindMyPlayerQuests();
        questPlayer.AddQuest(quest);
        quest.IsActive = true;
        //y 2) mostrar quest y progreso en UI ( la ui podria hacer esto sola ya que quest es un scriptable obj )
    }

    private void DialogueInteract(GameObject go)
    {
        Instantiate(go,transform,)
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