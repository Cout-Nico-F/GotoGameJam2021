using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    private Quest quest;

    private void Update()
    {
        List<Goal> goals = quest.Goals;

        foreach (var goal in goals)
        {
            //la ui se va a fijar si la quest esta activa, y si esta activa va a mostrar su shortDesc en un textfield
            //Segun como hagamos la ui, va a tener un maximo de textos para mostrar ( podemos limitarnos a 3 o 5 misiones )
            //necesita saber si tiene campos vacios
            //saber agregar texto al siguiente campo vacio
            //saber mover los campos al completar una mision para que el vacio sea siempre el ultimo

        }
    }

    public void AssignQuest(Quest quest)
    {
        this.quest = quest;
    }
}
