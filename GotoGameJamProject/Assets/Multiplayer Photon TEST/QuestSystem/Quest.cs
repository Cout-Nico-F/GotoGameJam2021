using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    private string name;
    private string desc;
    private int id;

    private QuestState state;

    public QuestState State { get => state; set => state = value; }
}
