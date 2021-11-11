using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPlayer : MonoBehaviour
{
    private List<Quest> questList = default;

    public List<Quest> QuestList { get => questList; }
}
