using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private QuestBase[] quests;
    private QuestPlayer questPlayer;
    [SerializeField] private GameObject questDialogue;
    [SerializeField] private RectTransform dialogueCanvas;
    public GameObject QuestDialogue { get => questDialogue; }

    public void ShowQuest(QuestPlayer questPlayer)
    {
        foreach (var quest in quests)
        {
            if (quest.Completed == false)
            {
                //para simplificar: las misiones no se aceptan.
                GiveQuest(quest, questPlayer);
                return;
            }
        }
    }

    private void GiveQuest(QuestBase quest, QuestPlayer questPlayer)
    {
        DialogueInteract(questDialogue);
        //questPlayer = FindMyPlayerQuests();
        questPlayer.AddQuest(quest);
        quest.IsActive = true;
        //y 2) mostrar quest y progreso en UI ( la ui podria hacer esto sola ya que quest es un scriptable obj )
    }

    private void DialogueInteract(GameObject go)
    {
        var ui = Instantiate(go, dialogueCanvas);
        
        ui.SetActive(true);
            
        //if (go.activeSelf == false)
        //{
        //    go.SetActive(true);
        //}
        //else
        //{
        //    go.GetComponentInChildren<DialogueJam.DialogueSystem>().NextText = true;
        //}
    }

    public bool QuestsAvailable()
    {
        foreach (var quest in quests)
        {
            if (quest.Completed == false)
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