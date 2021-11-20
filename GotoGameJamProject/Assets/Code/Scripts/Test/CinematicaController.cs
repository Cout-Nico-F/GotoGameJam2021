using DialogueJam;
using System;
using UnityEngine;

public class CinematicaController : MonoBehaviour
{
    public event Action<bool> OnDialogueEnds;

    [SerializeField] private GameObject dialoguePrefab;
    [SerializeField] private RectTransform dialogueCanvas;

    private DialogueSystem dialogueSystem;
    private bool isTalking;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isTalking)
        {
            ShowDialogue();
        }
    }


    private void ShowDialogue()
    {
        DialogueInteract(dialoguePrefab);
    }


    private void DialogueInteract(GameObject dialoguePrefab)
    {
        var ui = Instantiate(dialoguePrefab, dialogueCanvas.transform);
        ui.SetActive(true);
        isTalking = true;

        dialogueSystem = ui.GetComponentInChildren<DialogueSystem>();
        if (dialogueSystem != null)
        {
            dialogueSystem.OnDialogueEnds += HandleDialogueEnds;
        }
    }


    private void HandleDialogueEnds(bool dialogueEnds)
    {
        if (dialogueEnds)
        {
            isTalking = false;
            dialogueSystem.OnDialogueEnds -= HandleDialogueEnds;
        }
    }
}
