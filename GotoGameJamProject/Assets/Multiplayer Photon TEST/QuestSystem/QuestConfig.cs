using UnityEngine;

[CreateAssetMenu]
public class QuestConfig : ScriptableObject
{
    [SerializeField] private bool finished;

    public bool Finished { get => finished; set => finished = value; }
}
