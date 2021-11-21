using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineManager : MonoBehaviour
{
    [SerializeField] private GameObject goddesDialogue;
    [SerializeField] private RectTransform dialogueCanvas;
    [SerializeField] private Animator animator;



    public void GoddesDialogue()
    {
        DialogueInteract(goddesDialogue);
    }

    private void DialogueInteract(GameObject go)
    {
        var ui = Instantiate(go, dialogueCanvas.transform);
        ui.SetActive(true);
    }

    public void GoddesAppears()
    {
        animator.SetTrigger("GoddesAppears");
    }

}
