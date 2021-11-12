using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    private QuestState questState;

    private void Start()
    {
        if (questState.Finished)
        {
            //mostrar dialogo idle o siguiente mision
        }
        else
        {
            //mostrar mision actual
        }
    }
}
