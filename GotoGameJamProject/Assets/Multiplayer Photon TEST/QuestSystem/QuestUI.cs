using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private Quest[] quests;
    private void Update()
    {
        foreach (var quest in quests)
        {
            //la ui se va a fijar si la quest esta activa, y si esta activa va a mostrar su shortDesc en un textfield
            //Segun como hagamos la ui, va a tener un maximo de textos para mostrar ( podemos limitarnos a 3 o 5 misiones )
            //necesita saber si tiene campos vacios
            //saber agregar texto al siguiente campo vacio
            //saber mover los campos al completar una mision para que el vacio sea siempre el ultimo

        }
    }
}
