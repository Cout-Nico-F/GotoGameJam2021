using UnityEngine;

public class Quest : ScriptableObject
{
    [SerializeField] private bool isFinished;
    //o tengo que instanciar una ui de texto con setparent 

    private bool isActive;
    private string questName;
    private string desc;
    private int id;
    public bool IsFinished { get => isFinished; set => isFinished = value; }
    public bool IsActive { get => isActive; set => isActive = value; }
    public string QuestName { get => questName; }
    public string Desc { get => desc; }
    public int Id { get => id; }
}