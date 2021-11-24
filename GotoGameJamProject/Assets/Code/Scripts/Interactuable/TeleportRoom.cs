using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRoom : MonoBehaviour
{
    [SerializeField] private Vector3 ubication;
    [SerializeField] private int areaIndex;
    [SerializeField] private bool transition;

    private CameraController cameraController;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(transition)
            {
                collision.transform.Find("Canvas").transform.Find("ContainterTransicion").gameObject.SetActive(true);
                   
            }
            collision.transform.position = ubication;

            cameraController = collision.transform.Find("Camera").GetComponent<CameraController>();
            if (cameraController == null)
            {
                Debug.LogError("Componente CameraController no encontrado en el Player");
                return;
            } 

            cameraController.ChangeArea(areaIndex);
        }
    }
}
