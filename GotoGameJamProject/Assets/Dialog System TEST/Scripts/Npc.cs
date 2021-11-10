using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour, Interactable
{
    [SerializeField] private GameObject dialogue1;
    public void Interact()
    {
        dialogue1.SetActive(true);
    }
}
