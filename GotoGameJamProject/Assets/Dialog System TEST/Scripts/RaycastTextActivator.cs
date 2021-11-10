
using UnityEngine;
using Photon.Pun;

public class RaycastTextActivator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("This message will be shown when we are near an interactable item.")]
    private string labelText;//message to show
    private bool interactableDetected;
    [SerializeField]
    private float rayRadius;//used for assigning length to raycast
    private bool buttonInUse = false;
    [SerializeField]
    [Tooltip("Percentage of screen width that prompt takes up.")]
    private float promptWidthPercent;
    private float promptWidthCalculated;
    private float promptXValue;

    [SerializeField]
    [Tooltip("Percentage of screen height that prompt takes up.")]
    private float promptHeightPercent;
    private float promptHeightCalculated;

    private Collider2D[] myObjectsHit = default;
    private PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        promptWidthCalculated = Screen.width * (promptWidthPercent * .01f);//divide by 100 to convert to percent. Multiplication works the same but is faster.
        promptXValue = (Screen.width * 0.5f) - (promptWidthCalculated * 0.5f);

        promptHeightCalculated = Screen.height * (promptHeightPercent * .01f);//divide by 100 to convert to percent. Multiplication works the same but is faster.
    }


    private void Update()
    {

        if (photonView.IsMine)
        {
            if (Time.frameCount % 3 == 0)//runs these functions every three frames to save cpu cycles
            {
                myObjectsHit = null;

                myObjectsHit = Physics2D.OverlapCircleAll(transform.position, rayRadius);
                //cual es interactuable? ++por ahora el dev se encarga de que nunca halla 2 interactuables juntos
                foreach (var o in myObjectsHit)
                {
                    Debug.Log("Pasa por updatee");

                    if (o.transform.gameObject.GetComponent<Interactable>() != null)
                    {
                        Debug.Log("El circle colider me encontró. soy: " + o.transform.gameObject.name);
                    }
                }

                //if (Physics.Raycast(transform.position, transform.forward, out vision, rayLength))
                //{
                //    if (vision.collider.tag == "Interactuable")
                //    {
                //        Debug.Log("Interactable spotted!");
                //        interactableDetected = true;
                //    }
                //    else
                //    {
                //        interactableDetected = false;
                //    }
                //}
                //else
                //{
                //    interactableDetected = false;
                //}
            }

            //if (interactableDetected)
            //{
            //    if (Input.GetAxisRaw("Interact") != 0)
            //    {
            //        if (!buttonInUse)
            //        {
            //            //Debug.Log("button pressed");
            //            vision.collider.gameObject.GetComponent<Interactable>().Interact();//run function here
            //            buttonInUse = true;
            //        }
            //    }
            //    else
            //    {
            //        //Debug.Log("button not pressed");
            //        buttonInUse = false;
            //    }
            //}
        }
    }


    void OnGUI()
    {
        if (interactableDetected == true)
        {
            GUI.Box(new Rect(promptXValue, 0, promptWidthCalculated, promptHeightCalculated), (labelText));
        }
    }
}
