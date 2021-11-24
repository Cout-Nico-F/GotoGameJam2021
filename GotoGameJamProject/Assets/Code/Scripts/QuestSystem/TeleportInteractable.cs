using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportInteractable : MonoBehaviour, Interactable
{
    [SerializeField] private Vector3 teleportPosition;
    [SerializeField] private int areaIndex;

    private CameraController cameraController;


    public Vector3 TeleportPosition { get => teleportPosition; set => teleportPosition = value; }

    public void Interact(GameObject gameObject)
    {
        gameObject.transform.position = teleportPosition;
        gameObject.transform.Find("Canvas").transform.Find("ContainterTransicion").gameObject.SetActive(true);
        cameraController = gameObject.transform.Find("Camera").GetComponent<CameraController>();
        if (cameraController == null)
        {
            Debug.LogError("Componente CameraController no encontrado en el Player");
            return;
        }

        cameraController.ChangeArea(areaIndex);
    }
}
