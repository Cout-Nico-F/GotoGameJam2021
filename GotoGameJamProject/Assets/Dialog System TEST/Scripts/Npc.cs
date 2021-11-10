using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour, Interactable
{
    public void Interact()
    {
        Debug.Log("Soy interactuable y interactuo como un npc");
        throw new System.NotImplementedException();
    }
}
