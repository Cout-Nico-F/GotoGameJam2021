using System.Collections;
using System.Collections.Generic;
using DialogueJam;
using UnityEngine;

public class Npc : MonoBehaviour, Interactable
{
    [SerializeField] private GameObject dialogue1;
    public void Interact()
    {
        if (dialogue1.activeSelf==false)
        {
            dialogue1.SetActive(true);
        }
        else
        {
            dialogue1.GetComponentInChildren<DialogueSystem>().NextText=true;
        }
        
    }
}
