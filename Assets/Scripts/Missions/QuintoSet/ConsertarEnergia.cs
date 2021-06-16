using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsertarEnergia : MissionObjective
{
    public ConsertarEnergia(int _quantity) : base(_quantity){
        nome = "Conserte a energia na sala de computadores";
    }
    public override void AddObjetivo()
    {
        Engine.Instance.SetNight();
        PainelDeLuz.onComplete += OnTask;
    }
    public override void RemoveObjetivo()
    {
        PainelDeLuz.onComplete -= OnTask;
    }
}
