using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilhetesPerdidos : MissionObjective
{
    public BilhetesPerdidos(int _quantity) : base(_quantity){
        nome = "Encontre os bilhetes perdidos";
    }
    public override void AddObjetivo()
    {
        Bilhete.onPick += OnTask;
    }
    public override void RemoveObjetivo()
    {
        Bilhete.onPick -= OnTask;
    }
}
