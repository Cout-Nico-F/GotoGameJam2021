using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUno : QuestBase
{
    private void Start()
    {
        QuestName = "Quest Uno";
        Description = "Consigue recolertar todo";
        ExperienceReward = 100;

        Goals.Add(new CollectGoal(0, "Consigue 10 zanahorias", false, 0, 10)); // añade un nuevo Goal a la lista

        Goals.ForEach(g => g.Init()); // llama al metodo Init de cada Goal de la lista
    }
}
