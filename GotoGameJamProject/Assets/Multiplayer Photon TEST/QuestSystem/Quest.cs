using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    private QuestState state;

    public QuestState State { get => state; set => state = value; }
}
