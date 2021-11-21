using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportInteractable : MonoBehaviour, Interactable
{
    [SerializeField] private Vector3 teleportPosition;

    public void Interact(GameObject gameObject)
    {
        gameObject.transform.position = teleportPosition;
        gameObject.transform.Find("Canvas").transform.Find("ContainterTransicion").gameObject.SetActive(true);
    }
}
