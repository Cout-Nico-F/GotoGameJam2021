using UnityEngine;

[CreateAssetMenu]
public class QuestState : ScriptableObject
{

    [SerializeField] private bool finished;

    public bool Finished { get => finished; set => finished = value; }
}
