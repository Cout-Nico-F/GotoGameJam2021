using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// clase base para todos los Goals
public class Goal
{
    public string Description { get; set; }
    public bool Completed { get; set; }
    public int CurrentAmount { get; set; }
    public int RequiredAmount { get; set; }


    // este metodo lo sobreescribira cada Goal concreto para inicializar lo que necesite
    public virtual void Init()
    {

    }

    // comprobamos si se cumple el Goal
    public void Evaluate()
    {
        if (CurrentAmount >= RequiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        Completed = true;
    }
}
