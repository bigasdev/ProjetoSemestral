using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jantar : MissionObjective
{
    public Jantar(int _quantity) : base(_quantity){
        nome = "Vá jantar na praça de alimentação";
    }
    public override void AddObjetivo()
    {
        CutsceneTeste.onComplete += OnTask;
    }
    public override void RemoveObjetivo()
    {
        CutsceneTeste.onComplete -= OnTask;
    }
}
