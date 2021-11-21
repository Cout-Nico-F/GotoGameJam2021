using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CabinReference : MonoBehaviour
{
    [SerializeField] private TeleportInteractable teleport =default;
    [SerializeField] private Vector3 secondarySpot;

    QuestGiver myQuestGiver = default;
    private void Awake()
    {
        myQuestGiver = GetComponent<QuestGiver>();

        myQuestGiver.OnDialogueEnds += ChangeTeleportPosition;
    }

    public void ChangeTeleportPosition(bool condition)
    {
        teleport.TeleportPosition = secondarySpot;
    }
}
