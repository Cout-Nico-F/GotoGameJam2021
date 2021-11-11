using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] private GameObject dialogueQuest;
    
    private string name;
    private string desc;
    private int id;
    private QuestState state;

    public QuestState State { get => state; set => state = value; }
    public GameObject DialogueQuest { get => dialogueQuest; }
}
