using UnityEngine;

public class Quest : ScriptableObject
{
    [SerializeField] private bool isFinished;
    [SerializeField] private GameObject questDialogue;

    private bool isActive;
    private string questName;
    private string desc;
    private int id;
    public bool IsFinished { get => isFinished; set => isFinished = value; }
    public GameObject QuestDialogue { get => questDialogue; }
    public bool IsActive { get => isActive; set => isActive = value; }
    public string QuestName { get => questName; }
    public string Desc { get => desc; }
    public int Id { get => id; }
}