using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineManager : MonoBehaviour
{
    [SerializeField] private GameObject godessDialogueTransform;
    public void GoddesDialogue()
    {
        godessDialogueTransform.SetActive(true);
    }
}
