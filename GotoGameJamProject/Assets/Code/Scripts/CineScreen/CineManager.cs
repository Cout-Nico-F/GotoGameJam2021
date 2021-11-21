using UnityEngine;
using DialogueJam;
using UnityEngine.SceneManagement;


public class CineManager : MonoBehaviour
{
    [SerializeField] private GameObject goddesDialogue;
    [SerializeField] private RectTransform dialogueCanvas;
    [SerializeField] private Animator animator;

    private DialogueSystem dialogueSystem;


    public void GoddesDialogue()
    {
        DialogueInteract(goddesDialogue);
    }

    private void DialogueInteract(GameObject go)
    {
        var ui = Instantiate(go, dialogueCanvas.transform);
        ui.SetActive(true);
        dialogueSystem = ui.GetComponentInChildren<DialogueSystem>();
        if (dialogueSystem != null)
        {
            dialogueSystem.OnDialogueEnds += HandleDialogueEnds;
        }
    }

    private void HandleDialogueEnds(bool obj)
    {
        AudioJam.SoundManager.instance.Stop("CineMusic");
        SceneManager.LoadScene("Loading");
    }


    public void GoddesAppears()
    {
        animator.SetTrigger("GoddesAppears");
    }

}
