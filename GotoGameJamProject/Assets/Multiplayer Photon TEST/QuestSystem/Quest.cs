using UnityEngine;

public class Quest : ScriptableObject
{
    [SerializeField] private GameObject questDialogue;
    
    private QuestConfig questConfig;
    private string questName;
    private string desc;
    private int id;

    public QuestConfig QuestConfig { get => questConfig; }
    public GameObject QuestDialogue { get => questDialogue; }
    public string QuestName { get => questName; }
    public string Desc { get => desc; }
    public int Id { get => id; }
}
